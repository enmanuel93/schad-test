﻿using ShadPractice.Core.Contexts;
using ShadPractice.Core.Interfaces;
using ShadPractice.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Infrastructure.Services
{
    public class InvoiceDetailService : RepositoryBase<InvoiceDetail>, IInvoiceDetail
    {
        public InvoiceDetailService(TestInvoiceContext testInvoiceContext)
            : base(testInvoiceContext)
        {
        }
    }
}
