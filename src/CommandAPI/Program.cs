using CommandAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
// npgBuilder to use the user secrets
var npgBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("PostgreSqlConnection"));
npgBuilder.Username = builder.Configuration["UserID"];
npgBuilder.Password = builder.Configuration["Password"];
// dotnet 6 requires this to be added since we 
// bootstrap from the ground up
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(npgBuilder.ConnectionString));
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
var app = builder.Build();

// map the controllers
app.MapControllers();

app.Run();
