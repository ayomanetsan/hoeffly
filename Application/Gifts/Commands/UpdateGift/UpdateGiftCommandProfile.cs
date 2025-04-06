namespace Application.Gifts.Commands.UpdateGift;

public sealed class UpdateGiftCommandProfile : Profile
{
    public UpdateGiftCommandProfile()
    {
        CreateMap<UpdateGiftCommand, Gift>();
    }
}