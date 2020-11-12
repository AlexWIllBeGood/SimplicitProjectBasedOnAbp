using DataTransfer.Domain.Shared;
using DataTransfer.EntityFramework;
using System;
using Volo.Abp.Modularity;

namespace DataTransfer.Domain
{
    [DependsOn(typeof(DataTransferDomainSharedModule),
        typeof(DataTransferEntityFrameworkModule))]
    public class DataTransferDomainModule : AbpModule
    {
    }
}
