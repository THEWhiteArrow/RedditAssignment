using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    public Task<Post> CreateAsync(Post post);
    public Task<Post> GetByIdAsync(int id);
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto);
}