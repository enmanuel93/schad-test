using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Models
{
    public class Customer: Base
    {
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool   Status { get; set; }


        public int CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        public virtual CustomerTypes CustomerTypes { get; set; }


        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
