using Freelancer.Data;
using Freelancer.Web.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace Freelancer.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            // Init database

            System.Data.Entity.Database.SetInitializer(new FreelancerSeedData());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
