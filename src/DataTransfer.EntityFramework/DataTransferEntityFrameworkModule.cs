using DataTransfer.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace DataTransfer.EntityFramework
{
    [DependsOn(typeof(DataTransferDomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule))]
    public class DataTransferEntityFrameworkModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LocalMySqlDbContext>(builder =>
            {
                builder.AddDefaultRepositories(includeAllEntities: true);
            });

            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure<LocalMySqlDbContext>(ctx =>
                {
                    ctx.UseMySQL();
                });
            });

            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure<LocalMySqlDbContext>(ctx =>
                {
                    ctx.UseMySQL();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }
    }
}
