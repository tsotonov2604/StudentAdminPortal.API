using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlGenderRepository : IGenderRepository
    {
        private readonly StudentAdminContext _context;
        public SqlGenderRepository(StudentAdminContext context)
        {
            this._context = context;
        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Gender.ToListAsync();
        }
    }
}
