using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.IComm.IDomain
{
    public interface IReadTo<T> where T: class
    {
        T Find(int Id);

        T Find(Expression<Func<T, bool>> filter);

        IQueryable<T> Query(Func<DbSet<T>, IQueryable<T>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
