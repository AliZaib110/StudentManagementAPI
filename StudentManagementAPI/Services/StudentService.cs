using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
using System.Runtime.InteropServices;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET All Students
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }



        // Get Student by Id
        public async Task<Student?> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }



        //Create New Student 
        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }


        // Update Existing Student
        public async Task<Student?> UpdateStudent(Student student, int id)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Age = student.Age;
            existingStudent.Course = student.Course;
            existingStudent.Address = student.Address;

            await _context.SaveChangesAsync();
            return existingStudent;

        }


        //Delete Student
        public async Task<bool> DeleteStudent(int id)
        {
            var delStudent = await _context.Students.FindAsync(id);
            if(delStudent == null)
            {
                return false;
            }

            _context.Students.Remove(delStudent);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
