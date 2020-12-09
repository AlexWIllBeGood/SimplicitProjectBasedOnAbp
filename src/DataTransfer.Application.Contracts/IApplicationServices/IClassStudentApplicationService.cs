using DataTransfer.Domain.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;

namespace DataTransfer.Application.Contracts.IApplicationServices
{
    public interface IClassStudentApplicationService: IApplicationService
    {
        [UnitOfWork]
        Task<string> SendClassToMtsAsync(int productType, int branchId, List<CrmClassCourse> targetClasses,int classPerLevel, string SAId, string FTId, string LTId);
        [UnitOfWork]
        Task<string> SetClassProcessAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, int classPerLevel);
        [UnitOfWork]
        Task<string> SendStudentToMtsAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, int classPerLevel, int clasStatus, string classStudentStatus, bool needJoinClass = true);
    }
}
