using Dapr.Workflow;

namespace SubscriberAPI.Activities
{
    public class Activity3 : WorkflowActivity<string, bool>
    {
        public override async Task<bool> RunAsync(WorkflowActivityContext context, string input)
        {
            Console.WriteLine($"Activity3 for '{context.InstanceId}'");
            return true;
        }
    }
}
