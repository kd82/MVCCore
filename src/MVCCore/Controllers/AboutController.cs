using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCoreApplication.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController : Controller
    {

        public string Phone()
        {
            return "2347163645";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
