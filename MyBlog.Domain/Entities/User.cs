namespace MyBlog.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string TickName { get; set; }

        public int Gender { get; set; }

        public int Age { get; set; }

        public string JobName { get; set; }

        public string Signature { get; set; }

        public string Remark { get; set; }

        public virtual Role Role { get; set; } = new Role();
    }
}
