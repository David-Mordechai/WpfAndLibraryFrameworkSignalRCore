using Microsoft.AspNetCore.SignalR;

namespace WebApiDotnet6.Hubs;

public class MyHub : Hub
{
    private readonly ILogger<MyHub> _logger;

    public MyHub(ILogger<MyHub> logger)
    {
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("Client connected");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("Client disconnected");

        return base.OnDisconnectedAsync(exception);
    }
}