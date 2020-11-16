using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace DataTransfer.EntityFramework.DbMigrations
{
    [DependsOn(typeof(DataTransferEntityFrameworkModule))]
    public class DataTransferEntityFrameworkMigrationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddDbContext<LocalMySqlMigrationDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("LocalMysql"), null);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            
        }
    }
}
