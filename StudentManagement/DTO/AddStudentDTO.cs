namespace StudentManagement.DTO
{
    public class AddStudentDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
    }
}
