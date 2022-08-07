

using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;

namespace StudentManagement.Services.StudentService
{
    public class StudentService : IStudentService 
    {
        private static List<Student> students = new List<Student> {
             new Student(),
             new Student { Id =1, Name= "John"},
        };
        private readonly DataContext _context;


        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Student>>> AddStudent(Student newStudent)
        {  
          var response= new Response<List<Student>>();
          _context.Students.Add(newStudent);
          await _context.SaveChangesAsync();
          response.Data = await _context.Students.ToListAsync();
          return response;
        }

        public async Task<Response<List<Student>>> DeleteStudent(int id)
        {
            var response = new Response<List<Student>>();

            try
            {
                var student = await _context.Students.FirstAsync(c => c.Id == id);
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                response.Data = await _context.Students.ToListAsync();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<Student>>> GetAllStudents()
        {
            var dbStudents = await _context.Students.ToListAsync();
            var response = new Response<List<Student>>();

            response.Data = dbStudents;
            return response;
        }

        public async Task<Response<Student>> GetStudentById(int id)
        {
            var dbStudent = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            var response = new Response<Student>();
      
            response.Data = dbStudent;
            return response;
        }

        
         public async Task<Response<Student>> UpdateStudent(Student updatedStudent)
         {
            var response = new Response<Student>();

            try { 
            var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == updatedStudent.Id);
            student.Name = updatedStudent.Name;
            student.Gender = updatedStudent.Gender;

            await _context.SaveChangesAsync();
            response.Data = student;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false; 
            }

            return response;
        }
        
    }
}
