using DataTransfer.Application;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain;
using DataTransfer.EntityFramework;
using DataTransfer.EntityFramework.DbMigrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace DataTransfer.HttpApi.Host
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(DataTransferApplicationModule),
        typeof(DataTransferDomainModule),
        typeof(DataTransferEntityFrameworkModule),
        typeof(DataTransferEntityFrameworkMigrationModule))]
    public class DataTransferHttpApiHostModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            IConfiguration configuration = context.Services.GetConfiguration();
            ConfigureControllers(context);
            ConfigureSettings(context, configuration);
        }

        public void ConfigureControllers(ServiceConfigurationContext context)
        {
            context.Services.AddControllers();
        }

        public void ConfigureSettings(ServiceConfigurationContext context,IConfiguration configuration)
        {
            //配置Crm配置
            context.Services.ConfigureOptions<CRMOptions>(configuration.GetSection("CRMSettings"));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var env = context.GetEnvironment();
            var app = context.GetApplicationBuilder();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action}/{id?}"
                    );
            });
        }
    }
}
