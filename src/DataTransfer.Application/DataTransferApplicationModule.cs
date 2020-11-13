using DataTransfer.Application.Contracts;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain;
using DataTransfer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace DataTransfer.Application
{
    [DependsOn(typeof(DataTransferApplicationContractsModule),
        typeof(DataTransferDomainModule),
        typeof(AbpDddApplicationModule),
        typeof(DataTransferInfrastructureModule))]
    public class DataTransferApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
