using System.Linq;

namespace MyBlog.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public IQueryable<User> Users { get; set; }

        public IQueryable<RolePermssion> RolePermssions { get; set; }
    }
}
