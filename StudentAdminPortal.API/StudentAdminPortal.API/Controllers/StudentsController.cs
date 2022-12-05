using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using StudentAdminPortal.API.Commands;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using Student = StudentAdminPortal.API.DomainModels.Student;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("students/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);

            if (student == null) {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("students/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentCommand request)
        {
            var student = await studentRepository.UpdateStudent(studentId, request);

            if (student == null)
            {
                return NotFound();
            }
            else {
                return Ok(mapper.Map<Student>(student));
            }
    
        }

        [HttpDelete]
        [Route("students/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId) {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await studentRepository.DeleteStudent(studentId);
            return Ok(mapper.Map<Student>(student));
        }
    }
}
