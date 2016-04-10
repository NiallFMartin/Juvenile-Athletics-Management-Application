//Class automatically generated when project was created
using System.Web;
using System.Web.Mvc;

namespace JuvenileSportsManagementApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            //I added filter - Make sure user is logged in on any page bar the home page
            filters.Add(new AuthorizeAttribute());
        }
    }
}
