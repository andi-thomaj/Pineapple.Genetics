namespace Infrastructure.Options
{
    public class JwtOptions
    {
        public const string SectionName = nameof(JwtOptions);
        public required string Secret { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }
}
