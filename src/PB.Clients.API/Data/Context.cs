using Microsoft.EntityFrameworkCore;
using PB.Clients.API.Domain.Entities;

namespace PB.Clients.API.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options):base(options) 
    {
    } 
    public DbSet<Client> Clients { get; set; }
    

}
