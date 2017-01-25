using Microsoft.AspNetCore.Mvc;
using MvcCoreApplication.Services;
using System.Threading.Tasks;

namespace MvcCoreApplication.ViewComponents
{
    public class GreetingViewComponent:ViewComponent
    {
        private IGreeter _greeter;
        public GreetingViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _greeter.GetGreeting();
            return Task.FromResult<IViewComponentResult>(View("Default",model));
        }
    }
}
