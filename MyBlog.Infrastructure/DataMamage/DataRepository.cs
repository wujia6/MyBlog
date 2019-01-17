using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyBlog.IComm.IRepos;

namespace MyBlog.Infrastructure.DataMamage
{
    internal class DataRepository<T> : IReadTo<T> where T : class
    {
        private readonly ObjectContent objContext;

        public DataRepository(ObjectContent objcxt)
        {
            objContext = objcxt;
        }

        public T Find(int Id)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(Func<DbSet<T>, IQueryable<T>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            throw new NotImplementedException();
        }
    }
}
