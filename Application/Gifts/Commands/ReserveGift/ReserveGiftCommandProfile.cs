namespace Application.Gifts.Commands.ReserveGift;

public class ReserveGiftCommandProfile : Profile
{
    public ReserveGiftCommandProfile()
    {
        CreateMap<ReserveGiftCommand, SharedGift>()
            .ForMember(dest => dest.GiftId, opt => opt.MapFrom(src => src.GiftId));
    }
}
