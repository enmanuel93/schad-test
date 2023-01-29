using Microsoft.EntityFrameworkCore;
using ShadPractice.Core.Contexts;
using ShadPractice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Infrastructure.Services
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly TestInvoiceContext testInvoiceContext;

        public RepositoryBase(TestInvoiceContext testInvoiceContext)
        {
            this.testInvoiceContext = testInvoiceContext;
        }

        public IQueryable<T> FindAll() => testInvoiceContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            testInvoiceContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => testInvoiceContext.Set<T>().Add(entity);

        public void Update(T entity) => testInvoiceContext.Set<T>().Update(entity);

        public void Delete(T entity) => testInvoiceContext.Set<T>().Remove(entity);
    }
}
