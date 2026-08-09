
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentsController : ControllerBase
{
    //private readonly ApplicationDbContext _context;  // Dependency Injection

    //public StudentsController(ApplicationDbContext context)  // constructor
    //{
    //    _context = context;
    //}


    private readonly IStudentService _studentService;
    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // CRUD 1 : GET ALL Students

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        //var students = await _context.Students.ToListAsync();
        var students = await _studentService.GetAllStudents();
        return Ok(students);
    }

    // CRUD 2 : GET Student By ID

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _studentService.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);

    }

    // CRUD 3 : Create Student

    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Age = dto.Age,
            Course = dto.Course,
            Address = dto.Address

        };
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return CreatedAtAction(
            nameof(GetStudent),
            new { id = student.Id },
            student);
    }

    //CRUD 4 — Update Student

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
        if(id != student.Id)
        {
            return BadRequest();
        }

        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    // CRUD 5 : Delete Student

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if(student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);

        await _context.SaveChangesAsync();
        return NoContent();
    }


}


