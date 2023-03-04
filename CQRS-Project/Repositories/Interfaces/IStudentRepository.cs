using CQRS_Project.Models;

namespace CQRS_Project.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public Task<List<StudentDetails>> GetStudentListAsync();
        public Task<StudentDetails> GetStudentByIdAsync(int id);
        public Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        public Task<bool> UpdateStudentAsync(StudentDetails studentDetails);
        public Task<int> DeleteStudentAsync(int id);
    }
}
