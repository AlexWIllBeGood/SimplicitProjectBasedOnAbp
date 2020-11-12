using DataTransfer.Domain.Shared;
using System;
using Volo.Abp.Modularity;

namespace DataTransfer.Application.Contracts
{
    [DependsOn(typeof(DataTransferDomainSharedModule))]
    public class DataTransferApplicationContractsModule : AbpModule
    {
    }
}
