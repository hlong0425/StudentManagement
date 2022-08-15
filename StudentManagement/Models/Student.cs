using System.Text.Json.Serialization;

namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        [JsonIgnore]
        public List<Course> Courses { get; set; }               
    }
}
