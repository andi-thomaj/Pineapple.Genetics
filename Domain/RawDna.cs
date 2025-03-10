using Domain.Shared;

namespace Domain
{
    public class RawDna : BaseEntity
    {
        public required string FileName { get; set; }
        public byte[] GeneticFile { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
