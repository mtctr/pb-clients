using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Entities;

namespace PB.Clients.Tests.Fakes;

internal class FakeClientRepository : IClientRepository
{
    private readonly IList<Client> _clients;
    public FakeClientRepository()
    {
        _clients = new List<Client>();
    }
    public void Add(Client client)
    {
        _clients.Add(client);
    }

    public void Delete(Client client)
    {
        _clients.Remove(client);
    }

    public IEnumerable<Client> GetAll()
    {
        return _clients;
    }

    public Client GetByEmail(string email)
    {
        return _clients.FirstOrDefault(client => client.Email.Equals(email));
    }

    public Client GetById(string id)
    {
        return _clients.FirstOrDefault(client => client.Id.ToString().Equals(id));
    }

    public void Update(Client client)
    {
        var clientToRemove = _clients.First(clientDb => clientDb.Id.Equals(client.Id));
        _clients.Remove(clientToRemove);
        _clients.Add(client);
    }
}
