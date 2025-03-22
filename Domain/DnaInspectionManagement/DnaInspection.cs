namespace Domain.DnaInspectionManagement
{
    public class DnaInspection : BaseEntity
    {
        public string? Coordinates { get; set; }
        public required string FileName { get; set; }
        public byte[] GeneticFile { get; set; } = [];
        public bool IsDeleted { get; set; }
        public List<Country> Countries { get; set; } = [];
    }
}
