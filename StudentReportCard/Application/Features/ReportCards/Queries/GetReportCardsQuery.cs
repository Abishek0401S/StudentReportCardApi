using MediatR;
using StudentReportCard.Application.DTOs;

namespace StudentReportCard.Application.Features.ReportCards.Queries
{
    public class GetReportCardsQuery : IRequest<List<ReportCardDto>>
    {
        public List<Guid> StudentIds { get; set; }
    }

}
