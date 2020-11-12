using DataTransfer.Domain.Shared;
using System;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DataTransfer.Domain
{
    [DependsOn(typeof(DataTransferDomainSharedModule),
        typeof(AbpDddDomainModule))]
    public class DataTransferDomainModule : AbpModule
    {
    }
}
