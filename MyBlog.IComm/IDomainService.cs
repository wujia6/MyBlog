namespace MyBlog.IComm
{
    public interface IDomainService<T>: IRepository<T> where T: class
    { }
}
