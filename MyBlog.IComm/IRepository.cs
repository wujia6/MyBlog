using MyBlog.IComm.IDomain;

namespace MyBlog.IComm
{
    public interface IRepository<T>: IReadTo<T>, IWirteTo<T> where T: class
    {

    }
}
