using MyBlog.IComm.IRepos;

namespace MyBlog.IComm
{
    public interface IRepository<T>: IReadTo<T>, IWirteTo<T> where T: class
    {

    }
}
