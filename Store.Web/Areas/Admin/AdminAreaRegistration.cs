using System.Web.Mvc;

namespace Freelancer.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "AdminHome", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
               "Pet_default",
               "Admin/{controller}/{action}/{id}",
               new { controller = "Pet", action = "Add", id = UrlParameter.Optional }
           );
            context.MapRoute(
             "Employee_default",
             "Admin/{controller}/{action}/{id}",
             new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
         );
        }
    }
}