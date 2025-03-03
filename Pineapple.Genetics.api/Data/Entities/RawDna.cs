namespace Pineapple.Genetics.api.Data.Entities
{
    public class RawDna : BaseEntity
    {
        public byte[] GeneticFile { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
