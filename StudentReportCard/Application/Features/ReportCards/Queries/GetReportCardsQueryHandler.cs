using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentReportCard.Application.DTOs;
using StudentReportCard.Infrastructure.Persistence;

namespace StudentReportCard.Application.Features.ReportCards.Queries
{
    public class GetReportCardsQueryHandler : IRequestHandler<GetReportCardsQuery, List<ReportCardDto>>
    {
        private readonly ISchoolDbContext _context;

        public GetReportCardsQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportCardDto>> Handle(GetReportCardsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students
                .Where(s => request.StudentIds.Contains(s.Id))
                .Include(s => s.Class)
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Exam)
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Subject)
                .ToListAsync(cancellationToken);

            return students.Select(student => new ReportCardDto
            {
                StudentName = student.Name,
                ClassName = student.Class.ClassName,
                Section = student.Class.Section,
                AcademicYear = student.Class.AcademicYear,
                Exams = student.Marks
                    .GroupBy(m => m.Exam)
                    .Select(g => new ExamReportDto
                    {
                        ExamId = g.Key.Id,
                        ExamName = g.Key.Name,
                        Subjects = g.Select(m => new SubjectMarkDto
                        {
                            SubjectId = m.Subject.Id,
                            SubjectName = m.Subject.Name,
                            ObtainedMarks = m.ObtainedMarks,
                            MaximumMarks = m.MaximumMarks
                        }).ToList(),
                        TotalObtained = g.Sum(m => m.ObtainedMarks),
                        TotalMaximum = g.Sum(m => m.MaximumMarks),
                        Percentage = Math.Round((double)g.Sum(m => m.ObtainedMarks) / g.Sum(m => m.MaximumMarks) * 100, 2)
                    }).ToList()
            }).ToList();
        }
    }

}
