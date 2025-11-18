using NewClick.API.DTOs;

namespace NewClick.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}
