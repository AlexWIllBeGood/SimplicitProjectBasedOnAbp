using DataTransfer.Application;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain;
using DataTransfer.EntityFramework;
using DataTransfer.EntityFramework.DbMigrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
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
            ConfigureSwagger(context);
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
        public void ConfigureSwagger(ServiceConfigurationContext context)
        {
            context.Services.AddSwaggerGen(
                options =>
                {
                    options.DocInclusionPredicate((docName, description) => true);
                    //options.DocumentFilter<SwaggerEnumFilter>();
                    //options.OperationFilter<SwaggerUploadFileFilter>();
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "DataTransfer API", Version = "v1" });
                    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                    options.IncludeXmlComments(Path.Combine(basePath, "DataTransfer.HttpApi.Host.xml"));

                });
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

            app.UseSwagger();

            app.UseSwaggerUI(options=> {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "DataTransfer API");
            });

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
