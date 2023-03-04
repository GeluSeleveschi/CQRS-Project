using CQRS_Project.Models;
using CQRS_Project.Queries;
using CQRS_Project.Repositories.Interfaces;
using MediatR;

namespace CQRS_Project.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByIdAsync(query.Id);
        }


    }
}
