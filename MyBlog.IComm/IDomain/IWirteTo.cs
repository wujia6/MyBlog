namespace MyBlog.IComm.IDomain
{
    public interface IWirteTo<T> where T: class
    {
        bool Create(T entity);

        bool Remove(int id);

        bool Edit(T entity);

        int ExecPro(string sql, params object[] paramters);
    }
}
