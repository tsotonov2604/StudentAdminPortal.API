using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }
      
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Students
                .Include(nameof(Gender))
                .Include(nameof(Address)).ToListAsync();
        }
    }
}
