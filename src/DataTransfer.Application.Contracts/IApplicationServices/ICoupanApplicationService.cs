using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;

namespace DataTransfer.Application.Contracts.IApplicationServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICoupanApplicationService : IApplicationService
    {
        [UnitOfWork]
        Task<string> ChangeCoupanProductAsync();
    }
}
