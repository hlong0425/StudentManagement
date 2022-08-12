using AutoMapper;
using StudentManagement.DTO;

namespace StudentManagement
{
    public class OrganizationProfile: Profile
    {
        // https://docs.automapper.org/en/stable/Dependency-injection.html

        //https://docs.automapper.org/en/stable/Configuration.html#profile-instances

        //Create profile Instance:


        public OrganizationProfile()
        {        
            CreateMap<AddStudentDTO, Student>();
            CreateMap<Student, GetStudentDTO>();
            CreateMap<UpdateStudentDTO, Student>();

        }
    }
}
