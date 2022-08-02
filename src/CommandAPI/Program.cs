using CommandAPI.Data;

var builder = WebApplication.CreateBuilder(args);
// dotnet 6 requires this to be added since we 
// bootstrap from the ground up
builder.Services.AddControllers();
builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
var app = builder.Build();

// map the controllers
app.MapControllers();

app.Run();
