using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Commands
{
    public class UpdateStudentCommand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public long? Mobile { get; set; }
        public Guid? GenderId { get; set; }
    }
}
