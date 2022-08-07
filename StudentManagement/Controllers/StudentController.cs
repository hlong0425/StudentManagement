using Microsoft.AspNetCore.Mvc;
using StudentManagement.Services.StudentService;

namespace StudentManagement.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAll")]


        public async Task<ActionResult<Response<List<Student>>>> Get()
        {
            var res = await _studentService.GetAllStudents();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response<Student>>> GetSingle(int id)
        {
            var res = await _studentService.GetStudentById(id);
            return Ok(res);
        }


        [HttpPost]
        public async Task<ActionResult<Response<List<Student>>>> AddStudent(Student newStudent)
        {
            var res = await _studentService.AddStudent(newStudent);
            return Ok(res);
        }

        
        [HttpPut]
        public async Task<ActionResult<Response<Student>>> UpdateStudent(Student updatedStudent)
        {
            var res = await _studentService.UpdateStudent(updatedStudent);
            if(res.Data == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Response<Student>>> DeleteStudent(int id)
        {
            var res = await _studentService.DeleteStudent(id);
            if (res.Data == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
    }; 
};
