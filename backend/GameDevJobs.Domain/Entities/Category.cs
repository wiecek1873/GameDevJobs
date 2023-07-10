namespace GameDevJobs.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Offer> Offers { get; set; } = null!;
}
