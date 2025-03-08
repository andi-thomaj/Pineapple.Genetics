using Pineapple.Genetics.api.Data.Entities.Shared;

namespace Pineapple.Genetics.api.Data.Entities
{
    public class RawDna : BaseEntity
    {
        public required string FileName { get; set; }
        public byte[] GeneticFile { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
