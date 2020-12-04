using DataTransfer.Domain.Entities.CrmEntities;
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
    public class ClassDomainService : BaseDomainService, IClassDomainService
    {
        private readonly IClassCourseRepository _classCourseRepository;
        public ClassDomainService(
            IClassCourseRepository classCourseRepository,
        IUnitOfWorkManager unitOfWorkManager) : base(unitOfWorkManager)
        {
            this._classCourseRepository = classCourseRepository;
        }

        public async Task<List<CrmClassCourse>> GetClassCourseRange(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate)
        {
            var targetClasses = await _classCourseRepository
                .Include(e => e.ClassSchedules)
                .Include(e => e.Product)
                .Include(e => e.Branch)
                .Include(e => e.SA)
                .Include(e => e.LT)
                .Include(e => e.FT)
                .Include(e => e.ClassStudents)
                .Where(e =>
                e.Product.Prod_Type == productType
                && (e.Clas_BranID == branchId || e.Clas_BranID == 100000000)
                && e.Clas_Status == clasStatus
                && e.Clas_Deleted == 0
                && e.Clas_ActualBeginDate > beginTimeDate
                && e.Clas_ActualBeginDate <= endTimeDate
                ).ToListAsync();

            return targetClasses;
        }
    }
}
