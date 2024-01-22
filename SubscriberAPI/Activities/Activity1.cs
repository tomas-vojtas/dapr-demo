using Dapr.Workflow;
using SubscriberAPI.Interfaces;

namespace SubscriberAPI.Activities
{
    public class Activity1 : WorkflowActivity<string, bool>
    {
        private ITestService _testService;

        public Activity1(ITestService testService)
        {
            _testService = testService;
        }

        public override async Task<bool> RunAsync(WorkflowActivityContext context, string input)
        {
            Console.WriteLine($"Activity1 for '{context.InstanceId}'");
            _testService.Do();
            return true;
        }
    }
}
