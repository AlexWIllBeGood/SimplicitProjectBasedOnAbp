using DataTransfer.EntityFramework.Repositories.CrmRepositories;
using DataTransfer.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DataTransfer.Application.CrmServices
{
    public class CourseService : ApplicationService
    {
        private readonly IOptionsMonitor<CRMOptions> _classOptions;
        private readonly ClassCourseRepository _classCourseRepository;
        public CourseService(IOptionsMonitor<CRMOptions> classOptions, ClassCourseRepository classCourseRepository)
        {
            this._classOptions = classOptions;
            this._classCourseRepository = classCourseRepository;
        }

        /// <summary>
        /// 发送班级数据到MTS
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendClassToMtsAsync()
        {
            try
            {
                var Nov = Convert.ToDateTime("2020-11-13");
                ////筛选出目标班级
                ////HttpHelper.PostAsync();
                var targetClass = await _classCourseRepository
                    .Include(e => e.Product)
                    .Where(e =>
                    e.Product.Prod_Type == 3
                    && e.Clas_BranID == 101005000
                    && e.Clas_Status == 1
                    && e.Clas_Deleted == 0
                    && e.Clas_ActualBeginDate != null
                    && e.Clas_ActualBeginDate > Nov
                    ).ToListAsync();

                //var 

                return "yes";
            }
            catch (Exception ex)
            {

                return "erro";
            }
            
        }

        public async Task<string> SendStudentToMtsAsync()
        {
            try
            {
                return "yes";
            }
            catch (Exception ex)
            {

                return "error";
            }
        }
    }
}
