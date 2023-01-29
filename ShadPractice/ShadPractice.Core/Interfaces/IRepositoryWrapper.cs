using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomer Customer { get; }

        IInvoice Invoice { get; }

        IInvoiceDetail InvoiceDetail { get; }

        ICustomerTypes CustomerTypes { get; }

        void Save();
    }
}
