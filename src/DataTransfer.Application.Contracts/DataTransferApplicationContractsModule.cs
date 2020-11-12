using DataTransfer.Domain.Shared;
using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace DataTransfer.Application.Contracts
{
    [DependsOn(typeof(DataTransferDomainSharedModule),
        typeof(AbpDddApplicationContractsModule))]
    public class DataTransferApplicationContractsModule : AbpModule
    {
    }
}
