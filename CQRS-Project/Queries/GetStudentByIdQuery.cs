using CQRS_Project.Models;
using MediatR;

namespace CQRS_Project.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
