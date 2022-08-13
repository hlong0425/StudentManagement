namespace StudentManagement.DTO
{
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public List<Course> Courses { get; set; }
    }
}
