using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Post
{   
    [Key]
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Body { get; private set;}
    public string OwnerUsername { get; set; }

    public Post(string title, string body, string ownerUsername)
    {
        Title = title;
        Body = body;
        OwnerUsername = ownerUsername;
    }
    public Post(){}
}