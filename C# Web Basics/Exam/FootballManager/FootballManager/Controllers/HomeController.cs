namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;

    public class HomeController : Controller
    {
        
        public HomeController(Request request)
            : base(request)
        {
            
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }
            return View();
        }
    }
}
