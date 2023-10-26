namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public string Username { get; set; }
    public string UsernameContains { get; set; }

    public SearchUserParametersDto(string username)
    {
        Username = username;
    }
}