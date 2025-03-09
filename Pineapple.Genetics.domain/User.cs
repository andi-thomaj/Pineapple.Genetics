using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
        public required string Settings { get; set; }
    }
}
