using CQRS_Project.Data;
using CQRS_Project.Models;
using CQRS_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
                        => await _appDbContext.Students.ToListAsync();

        public async Task<StudentDetails> GetStudentByIdAsync(int id)
                        => await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _appDbContext.Students.Add(studentDetails);
            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> UpdateStudentAsync(StudentDetails studentDetails)
        {
            if (studentDetails != null)
            {
                _appDbContext.Students.Update(studentDetails);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
                _appDbContext.Students.Remove(student);

            return await _appDbContext.SaveChangesAsync();
        }
    }
}
