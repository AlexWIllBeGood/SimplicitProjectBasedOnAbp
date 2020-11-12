using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DataTransfer.EntityFramework
{
    public class DataTransferEntityFrameworkModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LocalMySqlDbContext>(builder=> {
                builder.AddDefaultRepositories(includeAllEntities: true);
            });

            context.Services.Configure<AbpDbContextOptions>(options=> {
                options.UseMySQL();
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }
    }
}
