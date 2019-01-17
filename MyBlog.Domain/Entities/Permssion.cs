using System.Linq;

namespace MyBlog.Domain.Entities
{
    public class Permssion
    {
        public int Id { get; set; }

        public int Pid { get; set; }

        public string Display { get; set; }

        public string Module { get; set; }

        public string Action { get; set; }

        public string Remark { get; set; }

        public IQueryable<RolePermssion> RolePermssions { get; set; }
    }
}
