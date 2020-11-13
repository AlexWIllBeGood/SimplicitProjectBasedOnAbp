using DataTransfer.EntityFramework.Repositories.CrmRepositories;
using Microsoft.Extensions.Options;
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
            //筛选出目标班级
            
        }
    }
}
