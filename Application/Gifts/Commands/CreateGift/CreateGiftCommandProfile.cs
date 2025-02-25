using Application.Gifts.Commands.CreateGift;

namespace Application.Gifts.Commands;

public class CreateGiftCommandProfile : Profile
{
    public CreateGiftCommandProfile()
    {
        CreateMap<CreateGiftCommand, Gift>();
    }
}