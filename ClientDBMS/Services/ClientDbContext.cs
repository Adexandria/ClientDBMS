using ClientDBMS.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientDBMS.Services
{
    public class ClientDbContext :DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options):base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
