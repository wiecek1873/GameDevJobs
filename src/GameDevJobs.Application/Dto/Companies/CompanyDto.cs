namespace Backend.Application.Dto.Companies;

public class CompanyDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Website { get; set; }
}
