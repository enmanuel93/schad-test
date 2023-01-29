using ShadPractice.Core.Contexts;
using ShadPractice.Core.Interfaces;
using ShadPractice.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Infrastructure.Services
{
    public class InvoiceService : RepositoryBase<Invoice>, IInvoice
    {
        public InvoiceService(TestInvoiceContext testInvoiceContext)
            : base(testInvoiceContext)
        {
        }
    }
}
