namespace GameDevJobs.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Website { get; set; }
        public ICollection<Offer> Offers { get; set; } = null!;
    }
}
