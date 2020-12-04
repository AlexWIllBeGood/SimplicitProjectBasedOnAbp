using DataTransfer.Domain.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DataTransfer.Application.Contracts.IApplicationServices
{
    public interface ICourseService : IApplicationService
    {
        Task TestBranch();
        Task<string> SendClassToMtsAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, string SAId, string FTId, string LTId);
        Task<string> SetClassProcessAsync(int productType, int branchId, List<CrmClassCourse> targetClasses);
        Task<string> SendStudentToMtsAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, int clasStatus, string classStudentStatus, bool needJoinClass = true);
    }
}
