namespace Pineapple.Genetics.api.Data.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
    }
}
