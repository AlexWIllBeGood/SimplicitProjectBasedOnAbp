using DataTransfer.Application.Contracts;
using DataTransfer.Domain;
using System;
using Volo.Abp.Modularity;

namespace DataTransfer.Application
{
    [DependsOn(typeof(DataTransferApplicationContractsModule),
        typeof(DataTransferDomainModule))]
    public class DataTransferApplicationModule : AbpModule
    {
    }
}
