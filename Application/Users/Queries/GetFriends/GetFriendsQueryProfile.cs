namespace Application.Users.Queries.GetFriends;

public class GetFriendsQueryProfile : Profile
{
    public GetFriendsQueryProfile()
    {
        CreateMap<Friendship, FriendsResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom((src, _, _, context) => 
                src.Requester.Email == context.Items["UserEmail"].ToString() ? src.Recipient.Name : src.Requester.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom((src, _, _, context) => 
                src.Requester.Email == context.Items["UserEmail"].ToString() ? src.Recipient.Email : src.Requester.Email))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
    }
}
