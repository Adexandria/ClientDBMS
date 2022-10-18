using ClientDBMS.Model;
using FluentNHibernate.Mapping;

namespace ClientDBMS.Services
{
    public class ClientMapping : ClassMap<Client>
    {
        public ClientMapping()
        {
            Id(x=>x.ClientId).GeneratedBy.Guid();
            Map(x => x.Address);
            Map(x=>x.FirstName);
            Map(x => x.MiddleName);
            Map(x=>x.LastName);
            Map(x=>x.Email);
            Map(x=>x.Phonenumber);

        }
    }
}
