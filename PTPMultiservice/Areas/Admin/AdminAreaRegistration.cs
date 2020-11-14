using System.Web.Mvc;

namespace PTPMultiservice.Areas.Admin
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
                //new { controller="Login", action = "Index", id = UrlParameter.Optional }
                new { controller = "Partners", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}