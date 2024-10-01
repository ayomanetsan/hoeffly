namespace Application.Wishlists.Commands.UpdateWishlist;

public class UpdateWishlistCommandValidator : AbstractValidator<UpdateWishlistCommand>
{
    public UpdateWishlistCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}
