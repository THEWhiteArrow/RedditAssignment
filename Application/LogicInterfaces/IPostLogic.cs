using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDto dto);
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto);
    public Task<Post> GetByIdAsync(int id);
}