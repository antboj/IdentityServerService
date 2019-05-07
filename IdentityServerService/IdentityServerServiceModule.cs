using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject;

namespace IdentityServerService
{
    [DependsOn(typeof(TestProjectWebCoreModule))]
    public class IdentityServerServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerServiceModule).GetAssembly());
        }
    }
}