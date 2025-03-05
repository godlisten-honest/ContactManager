using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Contracts.DTO
{
    public class ContactDto
    {
        public Guid ContactId { get; set; }
        public Guid CustomerId { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailAddress { get; set; }
    }
}
