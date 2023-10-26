namespace Domain.DTOs;

public class PostCreationDto
{
  
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string OwnerUsername{ get; set; } 

    public PostCreationDto(string title, string body, string ownerUsername)
    {
        Title = title;
        Body = body;
        OwnerUsername = ownerUsername;
    }
}