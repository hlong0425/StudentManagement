namespace StudentManagement.DTO
{
    public class AddStudentDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public List<Course> Courses { get; set; }
    }
}
