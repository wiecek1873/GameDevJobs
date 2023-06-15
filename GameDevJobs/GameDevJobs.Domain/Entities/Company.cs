namespace GameDevJobs.Domain.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Website { get; set; }
    public virtual ICollection<Offer> Offers { get; set; } = null!;
}
