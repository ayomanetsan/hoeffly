namespace Application.Users.Queries.GetUsers;

public record UsersResponse(

    // TODO: update schema to include photo url
    string Name,
    string Email)
{
    public UsersResponse()
        : this(string.Empty, string.Empty)
    {
    }
};
