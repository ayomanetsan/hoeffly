using Domain.Enums;

namespace Application.Gifts.Queries;

public record GiftResponse
{
    public required string Name { get; set; }

    public required Guid CategoryId { get; set; }

    public required string CategoryName { get; set; }

    public string? Note { get; set; }

    public string? ShopLink { get; set; }

    public string? PhotoLink { get; set; }

    public string? ThumbnailLink { get; set; }

    public double Price { get; set; }

    public Currency Currency { get; set; }

    public PriorityLevel Priority { get; set; }

    public int LikeCount { get; set; }

    public bool IsReserved { get; set; }

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gift, GiftResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
