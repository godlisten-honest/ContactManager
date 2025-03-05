
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Contracts.DTO
{
    public class CreateCustomerDto
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Collection<ContactDto> Contacts { get; set; }
    }
}
