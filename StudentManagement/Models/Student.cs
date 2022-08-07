namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Long";
        public Gender Gender { get; set; } = Gender.Male;
    }
}
