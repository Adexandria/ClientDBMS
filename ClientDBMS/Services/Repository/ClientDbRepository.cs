using ClientDBMS.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientDBMS.Services.Repository
{
    public class ClientDbRepository : IClient
    {
        private readonly ClientDbContext _db;
        public async Task CreateNewClient(Client newClient)
        {
           newClient.ClientId= Guid.NewGuid();
           await _db.Clients.AddAsync(newClient);
           await _db.SaveChangesAsync();
        }

        public async Task DeleteClient(Guid id)
        {
            var client = await GetExistingClientById(id);
            if(client is not null)
            {
                _db.Clients.Remove(client);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public IEnumerable<Client> GetAllClients()
        {
            var clients = _db.Clients.OrderBy(s=>s.ClientId);
            return clients;
        }

        public async Task<Client> GetExistingClientById(Guid id)
        {
            var client = await _db.Clients.FirstOrDefaultAsync(s => s.ClientId == id);
            return client;
        }

        public async Task UpdateClientAddress(Guid id, string address)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.Address = address;
                _db.Clients.Update(client);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public async Task UpdateClientLastname(Guid id, string lastname)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.LastName = lastname;
                _db.Clients.Update(client);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public async Task UpdateClientMiddlename(Guid id, string middlename)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.MiddleName = middlename;
                _db.Clients.Update(client);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public async Task UpdateClientName(Guid id, string firstname)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.FirstName = firstname;
                _db.Clients.Update(client);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public async Task UpdateClientPhonenumber(Guid id, string phonenumber)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.Phonenumber = phonenumber;
                _db.Clients.Update(client);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

    }
}
