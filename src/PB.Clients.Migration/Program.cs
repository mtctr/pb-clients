using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PB.Clients.API.Data;

Console.WriteLine("Applying migrations");
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("DbContext");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));

var app = builder.Build();
var context = (Context)app.Services.GetRequiredService(typeof(Context));
context.Database.Migrate();


Console.WriteLine("Done");