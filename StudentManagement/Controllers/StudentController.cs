using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DTO;
using StudentManagement.Services.StudentService;

namespace StudentManagement.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<Response<List<GetStudentDTO>>>> Get()
        {
            var res = await _studentService.GetAllStudents();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response<GetStudentDTO>>> GetSingle(int id)
        {
            var res = await _studentService.GetStudentById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Response<List<GetStudentDTO>>>> AddStudent(AddStudentDTO newStudent)
        {
            var res = await _studentService.AddStudent(newStudent);
            return Ok(res);
        }

        [HttpPost]
        [Route("{addCourse}")]
        public async Task<ActionResult<Response<List<GetStudentDTO>>>> AddCourse(AddCourseDTO addCourseParam)
        {
            var res = await _studentService.AddCourse(addCourseParam);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<Response<GetStudentDTO>>> UpdateStudent(UpdateStudentDTO updatedStudent)
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
