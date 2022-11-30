using Microsoft.AspNetCore.SignalR;

public class LikeHub : Hub {

    private Counter counter;

    public LikeHub(Counter counter) {
        this.counter = counter;
    }

    public async Task Like(string message)
    {
        this.counter.Like();
        await Clients.All.SendAsync("Liked", counter.Value);
    }

    public async Task Unlike(string message)
    {
        this.counter.Unlike();
        await Clients.All.SendAsync("Unliked", counter.Value);
    }

    public async Task Update(string message)
    {
        await Clients.Caller.SendAsync("Update", counter.Value);
    }

}