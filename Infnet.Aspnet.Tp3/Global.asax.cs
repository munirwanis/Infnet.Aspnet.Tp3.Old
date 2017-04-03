using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using Infnet.Aspnet.Tp3.Repository;
using Infnet.Aspnet.Tp3.Entities;
using Infnet.Aspnet.Tp3.Utility;

namespace Infnet.Aspnet.Tp3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Dependency Injection
            var container = new Container();

            container.Register<IConfigurationUtility, ConfigurationUtility>(Lifestyle.Singleton);
            container.Register<IRepository<BooksEntity>, BooksRepository>(Lifestyle.Singleton);
            container.Register<IContext, Context>(Lifestyle.Singleton);

            container.Verify();
            DependencyResolver.SetResolver(
            new SimpleInjectorDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
