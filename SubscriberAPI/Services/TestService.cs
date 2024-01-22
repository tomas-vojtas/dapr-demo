using Google.Api;
using SubscriberAPI.Interfaces;

namespace SubscriberAPI.Services
{
    public class TestService : ITestService
    {
        public void Do()
        {
            Console.WriteLine($"Code injected by dependency injection");
        }
    }
}
