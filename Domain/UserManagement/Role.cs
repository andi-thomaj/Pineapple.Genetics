using Domain.Shared;

namespace Domain.UserManagement
{
    public class Role : BaseEntity
    {
        public required string Name { get; set; }
        public List<User> Users { get; set; } = [];
    }

    public enum Roles
    {
        Admin = 1,
        Basic = 2
    }
}
