using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;
    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    { 
            int postId = 1;
            if (context.Posts.Any())
            {
                postId = context.Posts.Max(u => u.Id);
                postId++;
            }

            post.Id = postId;

            context.Posts.Add(post);
            context.SaveChanges();

            return Task.FromResult(post);
        }

    public Task<Post> GetByIdAsync(int id)
    {
        Post? post = context.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (dto.Title != null) posts = posts.Where(p => p.Title == dto.Title);
        if (dto.Id != -1) posts = posts.Where(p => p.Id == dto.Id);
        if (dto.OwnerUsername != null) posts = posts.Where(p => p.OwnerUsername == dto.OwnerUsername);
        if (dto.TitleContains != null) posts = posts.Where(p => p.Title.Contains(dto.TitleContains));

        return Task.FromResult(posts);

    }
}