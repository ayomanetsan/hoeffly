namespace Application.Gifts.Commands.CreateGift;

public sealed class CreateGiftCommandProfile : Profile
{
    public CreateGiftCommandProfile()
    {
        CreateMap<CreateGiftCommand, Gift>();
    }
}