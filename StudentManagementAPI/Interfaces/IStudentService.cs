using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student?> UpdateStudent(Student student, int id);
        Task<bool> DeleteStudent(int id);
    }
}
    