using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Entities;

namespace PB.Clients.API.Data.Repositories.Adapters;

public class ClientRepository : IClientRepository
{
    private readonly Context _context;

    public ClientRepository(Context context)
    {
        _context = context;
    }

    public void Add(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void Delete(Client client)
    {
        _context.Clients.Remove(client);
        _context.SaveChanges();
    }

    public IEnumerable<Client> GetAll()
    {
        return _context.Clients.ToList();
    }

    public Client GetByEmail(string email)
    {
        return _context.Clients.Where(client => client.Email.Equals(email)).FirstOrDefault();
    }

    public Client GetById(string id)
    {
        return _context.Clients.Where(client => client.Id.ToString().Equals(id)).FirstOrDefault();
    }
    public void Update(Client client)
    {
        _context.Update(client);
        _context.SaveChanges(true);
    }
}
