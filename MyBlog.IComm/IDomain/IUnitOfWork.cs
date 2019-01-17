using System;

namespace MyBlog.IComm.IDomain
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
