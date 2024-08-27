using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasKey(f => f.Id);

        builder.HasOne(f => f.Requester)
            .WithMany(u => u.Friendships)
            .HasForeignKey(f => f.RequesterId);

        builder.HasOne(f => f.Recipient)
            .WithMany()
            .HasForeignKey(f => f.RecipientId);

        builder.Property(f => f.Status)
            .IsRequired();
    }
}