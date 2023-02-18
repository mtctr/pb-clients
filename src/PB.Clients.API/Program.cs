using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB.Clients.API.Data;
using PB.Clients.API.Data.Repositories.Adapters;
using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Handlers.Adapters;
using PB.Clients.API.Domain.Handlers.Ports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbContext");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IHandler<CreateClientCommand>, CreatClientHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("/clients/create", ([FromBody]CreateClientCommand command, [FromServices]IHandler<CreateClientCommand> handler) =>
{
    return handler.Handle(command) as CommandResult;    
})
.WithName("CreateClient");

app.Run();