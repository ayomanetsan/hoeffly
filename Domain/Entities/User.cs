namespace Domain.Entities;

public class User : EntityBase
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string FirebaseUid { get; set; }

    public bool IsPublic { get; set; }

    public ICollection<Occasion> Occasions { get; } = new List<Occasion>();

    public ICollection<Friendship> Friendships { get; } = new List<Friendship>();

    public ICollection<SharedGift> SharedGifts { get; } = new List<SharedGift>();

    public ICollection<AccessRights> AccessRights { get; } = new List<AccessRights>();

    public ICollection<TeamUser> TeamUsers { get; } = new List<TeamUser>();

    public ICollection<Message> Messages { get; } = new List<Message>();
}