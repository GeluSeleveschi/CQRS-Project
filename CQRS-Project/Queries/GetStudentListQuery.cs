using CQRS_Project.Models;
using MediatR;

namespace CQRS_Project.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}
