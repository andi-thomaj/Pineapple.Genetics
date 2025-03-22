namespace Domain.DnaInspectionManagement
{
    public class Area : BaseEntity
    {
        public required string Name { get; set; }
        public int CountryId { get; set; }
        public required Country Country { get; set; }
    }
}
