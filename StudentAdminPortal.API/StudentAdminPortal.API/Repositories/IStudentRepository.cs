using StudentAdminPortal.API.Commands;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task <List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, UpdateStudentCommand request);
    }
}
