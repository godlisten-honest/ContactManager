using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Domain.Entities
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public Guid CustomerId { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string LastModifiedBy { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
