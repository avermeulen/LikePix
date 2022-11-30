var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

// Dependency injection
builder.Services.AddSingleton<Counter>();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<LikeHub>("/likes");

app.Run();
