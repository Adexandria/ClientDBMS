using System.ComponentModel.DataAnnotations;

namespace ClientDBMS.Model
{
    public class Client
    {
        [Key]
        public virtual Guid ClientId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName {get;set;}
        public virtual string LastName { get; set;}
        public virtual string Email { get; set; }
        public virtual string Phonenumber { get; set; }
        public virtual string Address { get; set; }

    }
}
