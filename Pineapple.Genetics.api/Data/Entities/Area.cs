using Pineapple.Genetics.api.Data.Entities.Shared;

namespace Pineapple.Genetics.api.Data.Entities
{
    public class Area : BaseEntity
    {
        public required string Name { get; set; }
        public Guid CountryId { get; set; }
        public required Country Country { get; set; }
    }
}
