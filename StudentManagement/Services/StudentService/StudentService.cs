

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.DTO;

namespace StudentManagement.Services.StudentService
{
    public class StudentService : IStudentService 
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<GetStudentDTO>>> AddStudent(AddStudentDTO newStudent)
        {  
            var response= new Response<List<GetStudentDTO>>();
            var student = _mapper.Map<Student>(newStudent);          
            _context.Students.Add(student);

            await _context.SaveChangesAsync();
            response.Data = await _context
                .Students
                .Select(student => _mapper.Map<GetStudentDTO>(student))
                .ToListAsync();
            return response;
        }

        public async Task<Response<List<GetStudentDTO>>> DeleteStudent(int id)
        {
            var response = new Response<List<GetStudentDTO>>();

            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
                if(student == null){
                    throw new Exception("Student is not exist");
                }
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                var students = await _context
                    .Students
                    .Select(student => _mapper.Map<GetStudentDTO>(student))
                    .ToListAsync();
                response.Data = students;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<GetStudentDTO>>> GetAllStudents()
        {
            var response = new Response<List<GetStudentDTO>>();
            try
            {
                var dbStudents = await _context
                    .Students
                    .Select(student => _mapper.Map<GetStudentDTO>(student))
                    .ToListAsync();

                response.Data = dbStudents;
            }

            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message; 
            }

            
            return response;
        }

        public async Task<Response<GetStudentDTO>> GetStudentById(int id)
        {
            var response = new Response<GetStudentDTO>();
            try { 
                var dbStudent = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
                if(dbStudent == null)
                {
                    throw new Exception("Student is not exist");
                }
                response.Data = _mapper.Map<GetStudentDTO>(dbStudent);
            }     
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }


            return response;
        }

        
         public async Task<Response<GetStudentDTO>> UpdateStudent(UpdateStudentDTO updatedStudent)
         {
            var response = new Response<GetStudentDTO>();

            try {
                var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == updatedStudent.Id);
                if (student == null)
                {
                    throw new Exception("Student is not exist");
                }
                _mapper.Map(updatedStudent, student);
                 await _context.SaveChangesAsync();
                 response.Data = _mapper.Map<GetStudentDTO>(student);                         
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
