namespace Application.Wishlists.Commands.ShareWishlist;

public class ShareWishlistCommandValidator : AbstractValidator<ShareWishlistCommand>
{
    public ShareWishlistCommandValidator()
    {
        RuleFor(x => x.WishlistId)
            .NotEmpty().WithMessage("WishlistId is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(x => x.AccessType)
            .IsInEnum().WithMessage("Invalid access type.");
    }
}
