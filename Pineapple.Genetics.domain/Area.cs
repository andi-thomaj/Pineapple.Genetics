using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain
{
    public class Area : BaseEntity
    {
        public required string Name { get; set; }
        public Guid CountryId { get; set; }
        public required Country Country { get; set; }
    }
}
