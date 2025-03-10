using Domain.Shared;

namespace Domain
{
    public class Country : BaseEntity
    {
        public required string Name { get; set; }
        public List<Area> Areas { get; set; } = [];
    }
}
