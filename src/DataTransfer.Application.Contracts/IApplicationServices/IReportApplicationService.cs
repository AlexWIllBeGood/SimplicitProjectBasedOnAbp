using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DataTransfer.Application.Contracts.IApplicationServices
{
    public interface IReportApplicationService : IApplicationService
    {
        Task<dynamic> GetClassRange(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate);
        Task<dynamic> GetStudentRange(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate, string classStatus);
    }
}
