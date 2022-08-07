using System.Text.Json.Serialization;

namespace StudentManagement.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
}
