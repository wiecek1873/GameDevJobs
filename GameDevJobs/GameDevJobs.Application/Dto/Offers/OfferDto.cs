using GameDevJobs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevJobs.Application.Dto.Offers;
public class OfferDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
    public int LocationId { get; set; }
    public virtual Location Location { get; set; } = null!;
    public virtual int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int WorkingTimeId { get; set; }
    public virtual WorkingTime WorkingTime { get; set; } = null!;
    public int? SeniorityId { get; set; }
    public virtual Seniority? Seniority { get; set; }
    public int? SalaryMin { get; set; }
    public int? SalaryMax { get; set; }
    public DateOnly Date { get; set; }
    public int Views { get; set; }
    public string Url { get; set; } = null!;
}
