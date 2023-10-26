using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    public Task<User> CreateAsync(User user);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto dto);
    public Task<User> GetByUsernameAsync(string username);
}