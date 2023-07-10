namespace GameDevJobs.Domain.Entities;

public class WorkingTime
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Offer> Offers { get; set; } = null!;
}
