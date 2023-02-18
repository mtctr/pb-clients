using PB.Clients.API.Domain.Entities;

namespace PB.Clients.API.Data.Repositories.Ports;

public interface IClientRepository
{
    void Add(Client client);
    IEnumerable<Client> GetAll();
    Client GetByEmail(string email);
    void Update(Client client);
    void Delete(Client client);

}
