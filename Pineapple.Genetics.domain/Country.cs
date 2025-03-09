using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain
{
    public class Country : BaseEntity
    {
        public required string Name { get; set; }
        public List<Area> Areas { get; set; } = [];
    }
}
