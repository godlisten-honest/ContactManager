using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Domain.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; }
        public string CreatedBy { get;set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string LastModifiedBy { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(Contact.Customer))]
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
