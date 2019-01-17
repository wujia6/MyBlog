using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBlog.IComm.IDomain;

namespace MyBlog.Infrastructure.DataManage
{
    public class Repository<T> : IReadTo<T> where T : class
    {
        public Repository(DbContext cxt)
        {
            Context = cxt;
        }

        /// <summary>
        /// 数据上下文对象
        /// </summary>
        private DbContext Context { get; }

        /// <summary>
        /// 数据表映射对象
        /// </summary>
        private DbSet<T> SetT => Context.Set<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T Find(int Id)
        {
            return SetT.Find(Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> filter)
        {
            if (filter==null)
                return null;
            return SetT.FirstOrDefault(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="include"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IQueryable<T> Query(
            Func<DbSet<T>, IQueryable<T>> include = null, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            include?.Invoke(SetT);
            if (filter!=null)
                SetT.Where(filter);
            orderby?.Invoke(SetT);
            return SetT.AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IQueryable<T> Query(
            int index, 
            int size, 
            out int total, 
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            if (filter != null)
                SetT.Where(filter);
            orderby?.Invoke(SetT);
            total = SetT.Count();
            return SetT.Skip((index - 1) * size).Take(size).AsQueryable();
        }
    }
}
