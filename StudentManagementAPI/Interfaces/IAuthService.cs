using StudentManagementAPI.DTOs;

namespace StudentManagementAPI.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterDto dto);
    }
}
