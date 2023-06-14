namespace GameDevJobs.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Offer> Offers { get; set; } = null!;
}
