﻿using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Commands;
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

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Students
                 .Include(nameof(Gender))
                 .Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId );
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Students
                .Include(nameof(Gender))
                .Include(nameof(Address)).ToListAsync();
        }

        public async Task<Student> UpdateStudent(Guid studentId, UpdateStudentCommand request)
        {
            var student = await context.Students.FindAsync(studentId);
            if (student != null) {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.Email = request.Email;
                student.DateOfBirth = (DateTime)request.DateOfBirth;
                student.Mobile = (long)request.Mobile;
                student.GenderId = (Guid)request.GenderId;

                
                await context.SaveChangesAsync();
                return student;
            }
            return null;
            
        }
    }
}
