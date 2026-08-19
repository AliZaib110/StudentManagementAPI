using BCrypt.Net;
using StudentManagementAPI.Data;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;


namespace StudentManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Register(RegisterDto dto)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

            if (existingUser != null)
            {
                return false;
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"

            };
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
