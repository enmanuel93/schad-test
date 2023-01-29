using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Models
{
    public class CustomerTypes: Base
    {
        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
