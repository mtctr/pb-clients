namespace PB.Clients.API.Domain.Entities;

public class Client
{
    public Client(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public void UpdateNameAndEmail(string newName, string newEmail)
    {
        this.Name = newName;
        this.Email = newEmail;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != this.GetType())
            return false;
        
        var paramObj = obj as Client;
        return paramObj.Id.Equals(this.Id);
    }

}
