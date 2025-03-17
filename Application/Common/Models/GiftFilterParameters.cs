using Domain.Enums;

namespace Application.Common.Models;

public class GiftFilterParameters
{
    public List<string>? CategoryNames { get; set; }
    
    public bool? IsReserved { get; set; }
    
    public List<PriorityLevel>? Priorities { get; set; }
}
