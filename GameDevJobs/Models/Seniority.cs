namespace GameDevJobs.Models;

public class Seniority
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Offer> Offers { get; set; } = null!;
}
