using Microsoft.Extensions.DependencyInjection;
using Unity.Services.CloudCode.Core;
using Unity.Services.CloudCode.Apis;

namespace PushExample
{
    public class PushExample
    {
        [CloudCodeFunction("SendPlayerMessage")]
        public async Task<string> SendPlayerMessage(IExecutionContext context, PushClient pushClient, string message, string messageType, string playerId)
        {
            var response = await pushClient.SendPlayerMessageAsync(context, message, messageType, playerId);
            return "Player message sent";
        }

        // Recommended to use access control to limit access to this endpoint
        [CloudCodeFunction("SendProjectMessage")]
        public async Task<string> SendProjectMessage(IExecutionContext context, PushClient pushClient, string message, string messageType)
        {
            var response = await pushClient.SendProjectMessageAsync(context, message, messageType);
            return "Project message sent";
        }
    }

    public class ModuleConfig : ICloudCodeSetup
    {
        public void Setup(ICloudCodeConfig config)
        {
            config.Dependencies.AddSingleton(PushClient.Create());
        }
    }
}