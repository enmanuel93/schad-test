using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Models
{
    public class InvoiceDetail: Base
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
