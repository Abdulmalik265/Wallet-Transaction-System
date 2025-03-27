using Microsoft.EntityFrameworkCore;
using WTS_CORE.Dto;
using WTS_CORE.Entities;
using WTS_CORE.Interface;
using WTS_INFRASTRUCTURE.Data;

namespace WTS_INFRASTRUCTURE.Repositories;

public class UserRegistrationRepo : IUserRegistration
{
    private readonly WtsDbContext _context;
    private IJwtGenerator _jwtGenerator;

    public UserRegistrationRepo(WtsDbContext context, IJwtGenerator jwtGenerator)
    {
        _context = context;
        _jwtGenerator = jwtGenerator;
    }
    public async Task<User> RegisterAsync(UserDto user)
    {
        try
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var account = new User()
            {
                Username = user.Username,
                PasswordHash = passwordHash,
                Email = user.Email,
                CreatedAt = DateTime.Now,
            };
            
            _context.Users.AddAsync(account);
            _context.SaveChanges();
            
            return account;

        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }

    }

    public async Task<string> LoginAsync(UserDto user)
    {
        var exisisting =  await _context.Users.AnyAsync(u => u.Username == user.Username);
        
        if(!exisisting)
            throw new Exception($"User {user.Username} not found");
        var account = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
        
        var token = _jwtGenerator.GenerateToken(account);
        
        return token;
        
        
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
