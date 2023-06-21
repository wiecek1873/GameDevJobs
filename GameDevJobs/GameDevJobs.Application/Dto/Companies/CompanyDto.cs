namespace GameDevJobs.Application.Dto.Companies;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Website { get; set; }
    public string Link { get; set; } = null!;
}
