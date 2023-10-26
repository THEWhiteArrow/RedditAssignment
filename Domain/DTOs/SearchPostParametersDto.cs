namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public int Id {get;}
    public string Title { get; }
    public string TitleContains { get; set; }
    public string OwnerUsername { get; }

    public SearchPostParametersDto(int id, string title, string titleContains, string ownerUsername)
    {
        Id = id;
        Title = title;
        TitleContains = titleContains;
        OwnerUsername = ownerUsername;
    }
}