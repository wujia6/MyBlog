using System;

namespace MyBlog.IComm.IRepos
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
