using DataTransfer.Domain.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace DataTransfer.Domain.IServices
{
    public interface IClassDomainService : IDomainService
    {
        Task<List<CrmClassCourse>> GetClassCourseRange(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate);
    }
}
