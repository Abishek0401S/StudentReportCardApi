using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentReportCard.Application.Features.ReportCards.Commands;
using StudentReportCard.Application.Features.ReportCards.Queries;

namespace StudentReportCard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDummyData()
        {
            var result = await _mediator.Send(new CreateStudentReportDataCommand());
            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> GetReportCards([FromBody] List<Guid> studentIds)
        {
            var query = new GetReportCardsQuery { StudentIds = studentIds };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
