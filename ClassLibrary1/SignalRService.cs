using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClassLibrary1
{
    public interface ISignalRService
    {
        Task ConnectAsync();
        Task DisconnectAsync();
    }

    public class SignalRService : ISignalRService
    {
        private readonly IRetryPolicy _retryPolicy;
        private HubConnection _connection;

        public SignalRService()
        {
            _retryPolicy = new RetryPolicy();
            _connection = BuildConnection();
        }

        private HubConnection BuildConnection()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5199/ws", HttpTransportType.WebSockets)
                .WithAutomaticReconnect(_retryPolicy)
                .Build();
            return _connection;
        }

        public async Task ConnectAsync()
        {
            try
            {
                if (_connection.State != HubConnectionState.Connected)
                    await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task DisconnectAsync()
        {
            try
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
