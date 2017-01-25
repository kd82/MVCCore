using Microsoft.AspNetCore.Mvc;

namespace MvcCoreApplication.ViewComponents
{
    public class LoginLogoutViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
