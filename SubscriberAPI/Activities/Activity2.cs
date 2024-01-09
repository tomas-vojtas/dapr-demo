using Dapr.Workflow;

namespace SubscriberAPI.Activities
{
    public class Activity2 : WorkflowActivity<string, bool>
    {
        public override async Task<bool> RunAsync(WorkflowActivityContext context, string input)
        {
            Console.WriteLine($"Activity2 for '{context.InstanceId}'");
            return true;
        }
    }
}
