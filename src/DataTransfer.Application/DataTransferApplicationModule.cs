using DataTransfer.Application.Contracts;
using DataTransfer.Domain;
using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace DataTransfer.Application
{
    [DependsOn(typeof(DataTransferApplicationContractsModule),
        typeof(DataTransferDomainModule),
        typeof(AbpDddApplicationModule))]
    public class DataTransferApplicationModule : AbpModule
    {
    }
}
