using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Infrastructure.Dtos
{
    public class InvoiceDtos
    {
        public int Code { get; set; }
        public int QTY { get; set; }
        public double UniPrice { get; set; }
        public double Total { get; set; }
    }
}
