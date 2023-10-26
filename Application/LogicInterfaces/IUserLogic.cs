using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreationDto dto);
    public Task<User> GetByUsernameAsync(string username);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto);

    public Task<User> ValidateUserAsync(string username, string password);

}