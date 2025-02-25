namespace Application.Gifts.Commands.UpdateGift;

public class UpdateGiftCommandProfile : Profile
{
    public UpdateGiftCommandProfile()
    {
        CreateMap<UpdateGiftCommand, Gift>();
    }
}