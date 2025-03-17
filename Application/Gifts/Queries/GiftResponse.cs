using Domain.Enums;

namespace Application.Gifts.Queries;

public record GiftResponse
{
    public required Guid Id { get; set; }

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
    
    public IEnumerable<SharedGiftResponse> SharedGifts { get; set; }
    
    public class SharedGiftResponse
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public SharedGiftStatus Status { get; set; }
    }
    
    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gift, GiftResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SharedGifts, opt => opt.MapFrom(src => src.SharedGifts));

            CreateMap<SharedGift, SharedGiftResponse>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
