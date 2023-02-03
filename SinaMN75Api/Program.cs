using SinaMN75Api.Core;
using SinaMN75Api.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.SetupUtilities<AppDbContext>(builder.Configuration.GetConnectionString("ServerSQLServer"));
builder.Services.AddSignalR();

WebApplication app = builder.Build();

app.UseUtilitiesServices();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/hubs/ChatHub");

app.Run();