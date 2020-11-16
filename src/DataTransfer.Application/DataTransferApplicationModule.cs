using DataTransfer.Application.Contracts;
using DataTransfer.Domain;
using DataTransfer.Infrastructure;
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
