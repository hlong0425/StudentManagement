namespace StudentManagement.Services.StudentService
{
    public interface IStudentService
    {
       Task<Response<List<Student>>> GetAllStudents();
       Task<Response<Student>> GetStudentById(int id);
       Task<Response<List<Student>>> AddStudent(Student newStudent);
       Task<Response<Student>> UpdateStudent(Student updatedStudent);
       Task<Response<List<Student>>> DeleteStudent(int id);

    }
}
