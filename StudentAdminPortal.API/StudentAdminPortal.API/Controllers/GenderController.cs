using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IGenderRepository genderRepository;
        private readonly IMapper mapper;

        public GenderController(IGenderRepository genderRepository, IMapper mapper)
        {
            this.genderRepository = genderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders() {

           var genders = await genderRepository.GetGendersAsync();

            if (genders == null || !genders.Any()) { 
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genders));
        }
    }
}
