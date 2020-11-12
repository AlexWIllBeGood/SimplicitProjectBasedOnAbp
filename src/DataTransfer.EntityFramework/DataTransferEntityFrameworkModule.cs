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
                //builder.AddDefaultRepositories(includeAllEntities: true);
            });

            context.Services.AddAbpDbContext<ABCCrmDbContext>(builder =>
            {
                //builder.AddDefaultRepositories(includeAllEntities: true);
            });

            //配置两个dbcontex使用不同的数据库
            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure<LocalMySqlDbContext>(ctx =>
                {
                    ctx.UseMySQL();
                });
                options.Configure<ABCCrmDbContext>(ctx =>
                {
                    ctx.UseSqlServer();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }
    }
}
