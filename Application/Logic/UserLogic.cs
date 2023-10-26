using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User(dto.Username, dto.Username);
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto)
    {
        return userDao.GetAsync(searchUserParametersDto);
    }
    
    public Task<User> GetByUsernameAsync(string username)
    {
        return userDao.GetByUsernameAsync(username);
    }

    public async Task<User> ValidateUserAsync(string username, string password)
    {
        User? user = await GetByUsernameAsync(username);
        if (user == null) throw new Exception("User doesnt exist");
        if (!user.Password.Equals(password)) throw new Exception("Password mismath");
        else return await Task.FromResult(user);
    }
}