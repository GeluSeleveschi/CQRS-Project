using CQRS_Project.Commands;
using CQRS_Project.Handlers;
using CQRS_Project.Models;
using CQRS_Project.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            var studentDetails = await _mediator.Send(new GetStudentListQuery());

            return studentDetails;
        }

        [HttpGet("studentId")]
        public async Task<List<StudentDetails>> GetStudentDetailsAsync()
        {
            var studentDetails = await _mediator.Send(new GetStudentListQuery());

            return studentDetails;
        }

        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var student = await _mediator.Send(new CreateStudentCommand(
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge));

            return student;
        }

        [HttpPut]
        public async Task<bool> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var studentDetailsUpdated = await _mediator.Send(new UpdateStudentCommand(
                studentDetails.Id,
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge
                ));

            return studentDetailsUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _mediator.Send(new DeleteStudentCommand() { Id = id });
        }
    }
}
