using System.Reflection;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.Interfaces;
using Autofac;
using Autofac.Integration.Mvc;

namespace Aliencube.ReCaptcha.Wrapper.WebApp
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacWebTypesModule());

            RegisterSettings(builder);
            RegisterServices(builder);
            RegisterControllers(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterSettings(ContainerBuilder builder)
        {
            builder.Register(p => ReCaptchaV2Settings.CreateInstance()).As<IReCaptchaV2Settings>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ReCaptchaV2>().As<IReCaptchaV2>();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
        }
    }
}