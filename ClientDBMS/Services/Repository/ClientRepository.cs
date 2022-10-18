using ClientDBMS.Model;
using NHibernate.Linq;

namespace ClientDBMS.Services.Repository
{
    public class ClientRepository : IClient
    {
        private readonly NHibernate.ISession _session;
        public ClientRepository(SessionFactory sessionFactory)
        {
            _session = sessionFactory._session;
        }
        public async Task CreateNewClient(Client newClient)
        {
            await _session.SaveAsync(newClient);
            await CommitAsync();
        }
      
        public IEnumerable<Client> GetAllClients()
        {
            var clients = _session.Query<Client>().OrderBy(s=>s.ClientId);
            return clients;
        }

        public async Task<Client> GetExistingClientById(Guid id)
        {
            var client = await _session.Query<Client>().FirstOrDefaultAsync(s=>s.ClientId == id);
            return client;
        }

        public async Task UpdateClientName(Guid id, string firstname)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.FirstName = firstname;
                await _session.UpdateAsync(client);
                await CommitAsync();
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
                await _session.UpdateAsync(client);
                await CommitAsync();
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
                await _session.UpdateAsync(client);
                await CommitAsync();
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
                await _session.UpdateAsync(client);
                await CommitAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public async Task UpdateClientAddress(Guid id, string address)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                client.Address = address;
                await _session.UpdateAsync(client);
                await CommitAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }

        public async Task DeleteClient(Guid id)
        {
            var client = await GetExistingClientById(id);
            if (client is not null)
            {
                await _session.DeleteAsync(client);
                await CommitAsync();
            }
            else
            {
                throw new InvalidOperationException("Client doesn't exist");
            }
        }


        protected async Task CommitAsync()
        {
            try
            {
                var transaction = _session.BeginTransaction();
                await transaction.CommitAsync();


            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
