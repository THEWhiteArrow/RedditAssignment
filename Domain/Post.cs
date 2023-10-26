namespace Domain;

public class Post
{
    public int Id { get; set; }
    public string Title { get; }
    public string Body { get; }
    public string OwnerUsername { get; set; }

    public Post(string title, string body, string ownerUsername)
    {
        Title = title;
        Body = body;
        OwnerUsername = ownerUsername;
    }
}