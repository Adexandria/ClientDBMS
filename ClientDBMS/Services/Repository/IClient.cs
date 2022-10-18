using ClientDBMS.Model;

namespace ClientDBMS.Services.Repository
{
    public interface IClient
    {
        Task CreateNewClient(Client newClient);
        Task<Client> GetExistingClientById(Guid id);
        IEnumerable<Client> GetAllClients();
        Task UpdateClientName(Guid id,string firstname);
        Task UpdateClientMiddlename(Guid id,string middlename);
        Task UpdateClientLastname(Guid id,string lastname);
        Task UpdateClientPhonenumber(Guid id,string phonenumber);
        Task UpdateClientAddress(Guid id,string address);
        Task DeleteClient(Guid id);
    }
}
