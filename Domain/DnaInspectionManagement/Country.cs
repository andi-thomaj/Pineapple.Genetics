using Domain.Shared;

namespace Domain.DnaInspectionManagement
{
    public class Country : BaseEntity
    {
        public required string Name { get; set; }
        public List<Area> Areas { get; set; } = [];
        public List<DnaInspection> DnaInspections { get; set; } = [];
    }
}
