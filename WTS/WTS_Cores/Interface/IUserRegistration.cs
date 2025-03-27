using WTS_CORE.Dto;
using WTS_CORE.Entities;

namespace WTS_CORE.Interface;

public interface IUserRegistration
{
    Task<User> RegisterAsync(UserDto user);
    Task<string> LoginAsync(UserDto user);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
    
}