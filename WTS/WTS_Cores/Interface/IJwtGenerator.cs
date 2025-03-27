using WTS_CORE.Dto;
using WTS_CORE.Entities;

namespace WTS_CORE.Interface;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}