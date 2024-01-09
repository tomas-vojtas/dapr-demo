using Dapr.Workflow;

namespace SubscriberAPI.Activities
{
    public class Activity1 : WorkflowActivity<string, bool>
    {
        public override async Task<bool> RunAsync(WorkflowActivityContext context, string input)
        {
            Console.WriteLine($"Activity1 for '{context.InstanceId}'");
            return true;
        }
    }
}
