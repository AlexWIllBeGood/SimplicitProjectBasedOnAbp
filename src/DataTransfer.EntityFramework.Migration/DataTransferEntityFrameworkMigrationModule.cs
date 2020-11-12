using System;
using Volo.Abp.Modularity;

namespace DataTransfer.EntityFramework.Migration
{
    [DependsOn(typeof(DataTransferEntityFrameworkModule))]
    public class DataTransferEntityFrameworkMigrationModule : AbpModule
    {
    }
}
