namespace MyBlog.Domain.Entities
{
    public class RolePermssion
    {
        public virtual Role Role { get; set; } = new Role();

        public virtual Permssion Permssion { get; set; } = new Permssion();
    }
}
