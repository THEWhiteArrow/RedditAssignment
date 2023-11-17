using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly RedditContext context;

    public UserEfcDao(RedditContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto dto)
    {
        IQueryable<User> users = context.Users.AsQueryable();
        IEnumerable<User> result = await users.ToListAsync();
        return result;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        User? existingUser = await context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
        return existingUser;
    }
}