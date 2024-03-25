using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.CloudCode;
using Unity.Services.CloudCode.Subscriptions;
using Unity.Services.Core;
using UnityEngine;
namespace CloudCode
{
    public class CloudCodeMessage : MonoBehaviour
    {
        async void Start()
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log(AuthenticationService.Instance.PlayerId);
            await SubscribeToPlayerMessages();
            await SubscribeToProjectMessages();
        }
        // This method creates a subscription to player messages and logs out the messages received,
        // the state changes of the connection, when the player is kicked and when an error occurs.
        Task SubscribeToPlayerMessages()
        {
            // Register callbacks, which are triggered when a player message is received
            var callbacks = new SubscriptionEventCallbacks();
            callbacks.MessageReceived += @event =>
            {
                Debug.Log(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"));
                Debug.Log($"Got player subscription Message: {JsonConvert.SerializeObject(@event, Formatting.Indented)}");
            };
            callbacks.ConnectionStateChanged += @event =>
            {
                Debug.Log($"Got player subscription ConnectionStateChanged: {JsonConvert.SerializeObject(@event, Formatting.Indented)}");
            };
            callbacks.Kicked += () =>
            {
                Debug.Log($"Got player subscription Kicked");
            };
            callbacks.Error += @event =>
            {
                Debug.Log($"Got player subscription Error: {JsonConvert.SerializeObject(@event, Formatting.Indented)}");
            };
            return CloudCodeService.Instance.SubscribeToPlayerMessagesAsync(callbacks);
        }
        // This method creates a subscription to project messages and logs out the messages received,
        // the state changes of the connection, when the player is kicked and when an error occurs.
        Task SubscribeToProjectMessages()
        {
            var callbacks = new SubscriptionEventCallbacks();
            callbacks.MessageReceived += @event =>
            {
                Debug.Log(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"));
                Debug.Log($"Got project subscription Message: {JsonConvert.SerializeObject(@event, Formatting.Indented)}");
            };
            callbacks.ConnectionStateChanged += @event =>
            {
                Debug.Log($"Got project subscription ConnectionStateChanged: {JsonConvert.SerializeObject(@event, Formatting.Indented)}");
            };
            callbacks.Kicked += () =>
            {
                Debug.Log($"Got project subscription Kicked");
            };
            callbacks.Error += @event =>
            {
                Debug.Log($"Got project subscription Error: {JsonConvert.SerializeObject(@event, Formatting.Indented)}");
            };
            return CloudCodeService.Instance.SubscribeToProjectMessagesAsync(callbacks);
        }
    }
}