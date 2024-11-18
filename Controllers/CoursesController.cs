using CourseManagementAPI.Data;
using CourseManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Create a new course
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] Course course)
    {
        if (string.IsNullOrEmpty(course.CourseName) || course.CourseDuration <= 0 || course.CourseFee <= 0)
        {
            return BadRequest("Invalid course data.");
        }

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
    }

    // Get all courses
    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        return Ok(await _context.Courses.ToListAsync());
    }

    // Get course by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound("Course not found.");
        return Ok(course);
    }

    // Update course details
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course updatedCourse)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound("Course not found.");

        course.CourseName = updatedCourse.CourseName;
        course.CourseDescription = updatedCourse.CourseDescription;
        course.CourseDuration = updatedCourse.CourseDuration;
        course.CourseFee = updatedCourse.CourseFee;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Delete a course
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound("Course not found.");

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}   