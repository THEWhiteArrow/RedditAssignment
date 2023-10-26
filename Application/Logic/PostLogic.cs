using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }


    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        // Post? existing = await postDao.GetByIdAsync(dto.Id);
        // if (existing != null)
        // {
        //     throw new Exception("Post already exists with the same Id!");
        // }
        
        ValidateData(dto);
        Post toCreate = new Post(dto.Title, dto.Body, dto.OwnerUsername);
        Post created = await postDao.CreateAsync(toCreate);

        return created;
    }

    private void ValidateData(PostCreationDto dto)
    {
        if( dto.Title.Length < 5 || dto.Body.Length < 5)
        throw new Exception("Invalid post data!");
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        return postDao.GetAsync(dto);
    }

    public Task<Post> GetByIdAsync(int id)
    {
        return postDao.GetByIdAsync(id);
    }
}