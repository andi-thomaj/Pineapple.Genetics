using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain
{
    public class RawDna : BaseEntity
    {
        public required string FileName { get; set; }
        public byte[] GeneticFile { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
