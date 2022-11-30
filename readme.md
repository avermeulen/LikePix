# LikePix - minimalistic SignalR app

A minimalistic SignalR app with a light sprinkle of Dependency Injection.

Start this app using the `ASP.NET Core Empty` template using this command: `dotnet new web -o LikePix`

## Server side setup

To use SignalR import the `Microsoft.AspNetCore.SignalR` package in a class that extends the `Hub` class. (`Microsoft.AspNetCore.SignalR.Hub`).

```c#
public class LikeHub : Hub {

    public async Task Like(string message)
    {
        // this.counter.Like();
        // await Clients.All.SendAsync("Liked", counter.Value);
    }

    public async Task Unlike(string message)
    {
        // this.counter.Unlike();
        // await Clients.All.SendAsync("Unliked", counter.Value);
    }
}
```

The `LikeHub` class will be exposed to the client side of the app using this command:

```js
app.MapHub<LikeHub>("/likes");
```

## Client Side setup


Setup a client side `wwwroot` folder using these two configurations:

```c#
app.UseDefaultFiles();
app.UseStaticFiles();
```

Create a `wwwroot` folder in the `root` folder of your app.

Create `index.js`, `index.html` and `style.css` files in the `wwwroot` folder.

Put some content in the `index.html` file and be sure to remove the default `app.MapGet('/')` route mapping in the `Program.cs` file.

Run the app using the `dotnet watch run` command.

Ensure you are happy with the setup bu changing contents in the `index.html` file and the contents should update accordingly.

To call the SignalR endpoint from client side JavaScript reference the `SignalR` client side code:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/7.0.0/signalr.min.js"></script>
```

Register a connection with SignalR using this command:

```js
const connection = new signalR.HubConnectionBuilder().withUrl("/likes").build();
```

Use code like this make calls once the SignalR connections has been established:

```js
connection.start().then(function () {
    //
}).catch(function (err) {
    return console.error(err.toString());
});
```

Register callback functions like this:


```js
connection.on("Liked", function(counter) {
    counterElem.innerText = counter;
});
```

Data can be send from the server to the client via parameters into the callback function.