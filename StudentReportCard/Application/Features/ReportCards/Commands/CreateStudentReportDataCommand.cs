using MediatR;

namespace StudentReportCard.Application.Features.ReportCards.Commands
{
    public class CreateStudentReportDataCommand : IRequest<string>
    {
        public Guid? StudentId { get; set; }
    }
}
