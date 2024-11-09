using System.Web.Mvc;

namespace K22cntt3_pvv_project2.Areas.AdminPvv
{
    public class AdminPvvAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPvv";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPvv_default",
                "AdminPvv/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}