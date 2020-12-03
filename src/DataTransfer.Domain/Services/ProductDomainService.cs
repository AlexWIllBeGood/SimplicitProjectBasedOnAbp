using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.Temp;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using DataTransfer.Domain.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace DataTransfer.Domain.Services
{
    public class ProductDomainService : BaseDomainService, IProductDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductLevelRepository _productLevelRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ICaptionRepository _captionRepository;

        public ProductDomainService(
            IProductRepository productRepository,
            IProductLevelRepository productLevelRepository,
            IProductTypeRepository productTypeRepository,
            ICaptionRepository captionRepository,
            IUnitOfWorkManager unitOfWorkManager
            ) : base(unitOfWorkManager)
        {
            this._productRepository = productRepository;
            this._productLevelRepository = productLevelRepository;
            this._productTypeRepository = productTypeRepository;
            this._captionRepository = captionRepository;
        }

        /// <summary>
        /// 配置产品类型
        /// </summary>
        /// <param name="productTypeCode"></param>
        /// <param name="productTypeName"></param>
        /// <returns></returns>
        public async Task<int> ConfigureProductType(string productTypeCode, string productTypeName, List<ProductOption> productOptions)
        {
            var pt = await _productTypeRepository.FirstOrDefaultAsync(e => e.Prot_Name == productTypeName);

            if (pt != null)
            {
                return -1;
            }

            var productType = new CrmProductType()
            {
                Prot_Code = productTypeCode,
                Prot_Name = productTypeName,
                Prot_CreatedBy = 1,
                Prot_CreatedDate = DateTime.Now,
                Prot_UpdatedBy = 1,
                Prot_UpdatedDate = DateTime.Now,
                Prot_Deleted = 0,
                Prot_ClassRule = 0,
                Prot_IsClassInsert = 1,
                Prot_IsBundle = 1,
                Prot_SaleRule = 0,
                Prot_SyncSys = "MTS",
            };
            List<CrmCaption> captions = await _captionRepository.Where(e => e.Capt_Family == "Clas_PeriodType" || e.Capt_Family == "Clas_ScaleType" || e.Capt_Family == "Clas_TeacherType").ToListAsync();
            foreach (var po in productOptions)
            {
                int? periodTypeId = captions.FirstOrDefault(e => e.Capt_CS == po.Clas_PeriodType)?.Capt_Order;
                int? scaleTypeId = captions.FirstOrDefault(e => e.Capt_CS == po.Clas_ScaleType)?.Capt_Order;
                int? teacherTypeId = captions.FirstOrDefault(e => e.Capt_CS == po.Clas_TeacherType)?.Capt_Order;

                productType.ProductSubTypes.Add(new CrmProductSubType()
                {
                    Clas_PeriodType = periodTypeId,
                    Clas_ScaleType = scaleTypeId,
                    Clas_TeacherType = teacherTypeId,
                    Prost_Name = $"{po.Clas_PeriodType}-{po.Clas_ScaleType}-{po.Clas_TeacherType}",
                    Prost_CreatedBy = 1,
                    Prost_CreatedDate = DateTime.Now
                });
            }
            await _productTypeRepository.InsertAsync(productType);
            await _uow.SaveChangesAsync();
            return productType.Prot_ID;
        }
        /// <summary>
        /// 配置产品级别
        /// </summary>
        /// <param name="productLevelName"></param>
        /// <param name="productLevelCount"></param>
        /// <returns></returns>
        public async Task<string> ConfigureProductLevel(string productLevelCode, string productLevelName, int productLevelCount)
        {
            var pls = await _productLevelRepository.Where(e => e.Prol_Name.Contains(productLevelName)).ToListAsync();

            if (pls.Any())
            {
                return string.Join(',', pls.Select(e => e.Prol_ID).OrderBy(e => e).ToList());
            }

            for (int i = 0; i < productLevelCount; i++)
            {
                var pl = new CrmProductLevel()
                {
                    Prol_Code = $"{productLevelCode}{i + 1}",
                    Prol_Name = $"{productLevelName}{i + 1}",
                    Prol_CreatedBy = 1,
                    Prol_CreatedDate = DateTime.Now,
                    Prol_UpdatedBy = 1,
                    Prol_UpdatedDate = DateTime.Now,
                    Prol_Deleted = 0,
                    Prol_Ab = (i + 1).ToString()
                };
                await _productLevelRepository.InsertAsync(pl);
                pls.Add(pl);
            }

            await _uow.SaveChangesAsync();

            return string.Join(',', pls.Select(e => e.Prol_ID).OrderBy(e => e).ToList());
        }
        /// <summary>
        /// 配置产品
        /// </summary>
        /// <param name="productOptions"></param>
        /// <returns></returns>
        public async Task<string> ConfigureProduct(string shortName, string productName, int productTypeId, string productLevelIds, int periodClassHour)
        {
            var productType = await _productTypeRepository
                .Include(e => e.ProductSubTypes)
                .FirstOrDefaultAsync(e => e.Prot_ID == productTypeId);
            List<CrmProduct> products = new List<CrmProduct>();
            foreach (var pst in productType.ProductSubTypes)
            {
                var product = new CrmProduct()
                {
                    Prod_Ab = shortName,
                    Prod_Name = $"{productName}({pst.Prost_Name})",
                    Prod_ClassHour = null,
                    Prod_Amount = 0,
                    Prod_TermType = 0,
                    Prod_Type = productTypeId,
                    Prod_SubTypeID = pst.Prost_ID,
                    Prod_CreatedBy = 1,
                    Prod_CreatedDate = DateTime.Now,
                    Prod_UpdatedBy = 1,
                    Prod_UpdatedDate = DateTime.Now,
                    Prod_Deleted = 0,
                    Prod_Status = 1,//默认禁用
                    Prod_Levels = productLevelIds,
                    Prod_PeriodClassHour = periodClassHour
                };
                await _productRepository.InsertAsync(product);
                products.Add(product);
            }
            await _uow.SaveChangesAsync();
            return string.Join(',', products.Select(e => e.Prod_ID).OrderBy(e => e).ToList());
        }
    }
}
