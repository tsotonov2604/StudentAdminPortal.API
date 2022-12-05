using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetGendersAsync();
    }
}
