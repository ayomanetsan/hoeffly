namespace Domain.Entities;

public class Message : EntityBase
{
    public required string Content { get; set; }

    public Guid SenderId { get; set; }

    public User Sender { get; set; } = null!;

    public Guid WishlistId { get; set; }

    public Wishlist Wishlist { get; set; } = null!;

    public Guid TeamId { get; set; }

    public Team Team { get; set; } = null!;

    public Guid? ReplyToMessageId { get; set; }

    public Message? ReplyToMessage { get; set; }

    public ICollection<Message> Replies { get; set; } = new List<Message>();
}