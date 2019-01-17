using System;
using System.Linq;
using MyBlog.IComm.IDomain;

namespace MyBlog.Domain.Entities
{
    public partial class Role: IAggregroot
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public IQueryable<User> Users { get; set; }

        public IQueryable<RolePermssion> RolePermssions { get; set; }
    }

    public partial class Role
    {

    }
}
