namespace Application.Users.Queries.GetUsers;

public record UsersResponse(
    string Name, 
    string Email
)
{
    public UsersResponse() : this("", ""){ }
};
