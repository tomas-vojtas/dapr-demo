using Dapr.Workflow;
using System;
using SubscriberAPI.Activities;
using SubscriberAPI.Models;

namespace SubscriberAPI.Workflows
{
    public class OrderProcessingWorkflow : Workflow<string, bool>
    {
        public override async Task<bool> RunAsync(WorkflowContext context, string input)
        {
            await context.CallActivityAsync<bool>(nameof(Activity1), input);
            //Console.WriteLine($"After Activity1, waiting for Step1 '{context.InstanceId}'");
            var event1 = await context.WaitForExternalEventAsync<Event1>(eventName: "event1");
            if (!event1.Success) return false;
            await context.CallActivityAsync<bool>(nameof(Activity2), input);
            var event2 = await context.WaitForExternalEventAsync<Event1>(eventName: "event2");
            if (!event2.Success) return false;
            await context.CallActivityAsync<bool>(nameof(Activity3), input);
            return true;
        }
    }
}
