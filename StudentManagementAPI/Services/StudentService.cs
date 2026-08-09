using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }
        public Task<Student> CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetStudent(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Student?> UpdateStudent(Student student, int id)
        {
            throw new NotImplementedException();
        }
    }
}
