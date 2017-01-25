using Microsoft.Extensions.Configuration;

namespace MvcCoreApplication.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }
    public class Greeter : IGreeter
    {
        private string _greeting;
        public Greeter(IConfiguration Configuration)
        {
            _greeting = Configuration["Greeting"];
        }
        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
