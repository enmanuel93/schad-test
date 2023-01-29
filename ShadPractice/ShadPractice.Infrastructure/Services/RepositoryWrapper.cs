using ShadPractice.Core.Contexts;
using ShadPractice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Infrastructure.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly TestInvoiceContext testInvoiceContext;

        private ICustomer _customerRepo;
        private IInvoice _invoice;
        private IInvoiceDetail _invoiceDetail;
        private ICustomerTypes _customerTypes;

        public ICustomer Customer
        {
            get
            {
                if (_customerRepo == null)
                {
                    _customerRepo = new CustomerService(testInvoiceContext);
                }
                return _customerRepo;
            }
        }

        public IInvoice Invoice
        {
            get
            {
                if (_invoice == null)
                {
                    _invoice = new InvoiceService(testInvoiceContext);
                }
                return _invoice;
            }
        }

        public IInvoiceDetail InvoiceDetail
        {
            get
            {
                if (_invoiceDetail == null)
                {
                    _invoiceDetail = new InvoiceDetailService(testInvoiceContext);
                }
                return _invoiceDetail;
            }
        }

        public ICustomerTypes CustomerTypes
        {
            get
            {
                if (_customerTypes == null)
                {
                    _customerTypes = new CustomerTypesService(testInvoiceContext);
                }
                return _customerTypes;
            }
        }

        public RepositoryWrapper(TestInvoiceContext testInvoiceContext)
        {
            this.testInvoiceContext = testInvoiceContext;
        }

        //method to save 
        public void Save()
        {
            testInvoiceContext.SaveChanges();
        }
    }
}
