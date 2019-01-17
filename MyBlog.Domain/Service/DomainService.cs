using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Data;
using MyBlog.IComm;
using MyBlog.IComm.IDomain;

namespace MyBlog.Domain.Service
{
    /// <summary>
    /// 领域通用服务类
    /// 处理领域模型业务逻辑
    /// </summary>
    /// <typeparam name="T">领域实体对象</typeparam>
    public class DomainService<T>: IRepository<T> where T: class
    {
        private readonly BlogContext blogContext;
        private readonly IReadTo<T> iQuery;

        public DomainService(BlogContext cxt, IReadTo<T> iquery)
        {
            blogContext = cxt;
            iQuery = iquery;
        }

        /// <summary>
        /// 数据表映射对象
        /// </summary>
        private DbSet<T> SetT => blogContext.Set<T>();

        /// <summary>
        /// 工作单元
        /// </summary>
        private IUnitOfWork UnitWork => blogContext as IUnitOfWork;

        #region ##实现IWirteTo仓储接口
        public bool Create(T entity)
        {
            if (entity == null)
                return false;
            blogContext.Entry(entity).State = EntityState.Added;
            return UnitWork.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var entity = Find(id);
            if (entity == null)
                return false;
            blogContext.Entry(entity).State = EntityState.Deleted;
            return UnitWork.SaveChanges() > 0;
        }

        public bool Edit(T entity)
        {
            if (entity == null)
                return false;
            blogContext.Attach(entity);
            blogContext.Entry(entity).State = EntityState.Modified;
            return UnitWork.SaveChanges() > 0;
        }

        public int ExecPro(string sql, params object[] paramters)
        {
            return blogContext.Database.ExecuteSqlCommand(sql, paramters);
        }
        #endregion

        #region ##重构IReadTo仓储接口方法
        public T Find(int Id)
        {
            return iQuery.Find(Id);
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            if (filter==null)
                return null;
            return iQuery.Find(filter);
        }

        public IQueryable<T> Query(Func<DbSet<T>, IQueryable<T>> include = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            return iQuery.Query(include, filter, orderby);
        }

        public IQueryable<T> Query(int index, int size, out int total, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            return iQuery.Query(index, size, out total, filter, orderby);
        }
        #endregion
    }
}
