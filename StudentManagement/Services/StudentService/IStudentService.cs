using StudentManagement.DTO;

namespace StudentManagement.Services.StudentService
{
    public interface IStudentService
    {
       Task<Response<List<GetStudentDTO>>> GetAllStudents();
       Task<Response<GetStudentDTO>> GetStudentById(int id);
       Task<Response<List<GetStudentDTO>>> AddStudent(AddStudentDTO newStudent);
       Task<Response<GetStudentDTO>> UpdateStudent(UpdateStudentDTO updatedStudent);
       Task<Response<List<GetStudentDTO>>> DeleteStudent(int id);
       Task<Response<GetStudentDTO>> AddCourse(AddCourseDTO addCourseParam);
    }
}
