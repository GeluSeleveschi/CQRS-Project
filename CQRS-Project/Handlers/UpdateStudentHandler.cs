using CQRS_Project.Commands;
using CQRS_Project.Repositories.Interfaces;
using MediatR;

namespace CQRS_Project.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (studentDetails == null) return default;

            studentDetails.StudentName = command.StudentName;
            studentDetails.StudentEmail = command.StudentEmail;
            studentDetails.StudentAddress = command.StudentAddress;
            studentDetails.StudentAge = command.StudentAge;

            return await _studentRepository.UpdateStudentAsync(studentDetails);
        }
    }
}
