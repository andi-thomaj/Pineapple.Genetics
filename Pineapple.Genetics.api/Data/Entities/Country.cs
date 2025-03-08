using Pineapple.Genetics.api.Data.Entities.Shared;

namespace Pineapple.Genetics.api.Data.Entities
{
    public class Country : BaseEntity
    {
        public required string Name { get; set; }
        public List<Area> Areas { get; set; } = [];
    }
}
