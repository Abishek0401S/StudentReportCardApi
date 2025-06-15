using MediatR;
using StudentReportCard.Domain.Entities;
using StudentReportCard.Infrastructure.Persistence;

namespace StudentReportCard.Application.Features.ReportCards.Commands
{
    public class CreateStudentReportDataCommandHandler : IRequestHandler<CreateStudentReportDataCommand, string>
    {
        private readonly ISchoolDbContext _context;

        public CreateStudentReportDataCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateStudentReportDataCommand request, CancellationToken cancellationToken)
        {
            var studentId = request.StudentId ?? Guid.NewGuid();
            var classId = Guid.NewGuid();
            var examId = Guid.NewGuid();
            var subject1Id = Guid.NewGuid();
            var subject2Id = Guid.NewGuid();

            var studentClass = new StudentClass
            {
                Id = classId,
                ClassName = "9th Grade",
                Section = "A",
                AcademicYear = "2024-2025"
            };

            var student = new Student
            {
                Id = studentId,
                Name = "John Wick",
                ClassId = classId
            };

            var exam = new Exam
            {
                Id = examId,
                Name = "Mid-Term"
            };

            var subject1 = new Subject { Id = subject1Id, Name = "Mathematics" };
            var subject2 = new Subject { Id = subject2Id, Name = "Science" };

            var marks1 = new Mark
            {
                StudentId = student.Id,
                ExamId = examId,
                SubjectId = subject1Id,
                ObtainedMarks = 80,
                MaximumMarks = 100
            };

            var marks2 = new Mark
            {
                StudentId = student.Id,
                ExamId = examId,
                SubjectId = subject2Id,
                ObtainedMarks = 75,
                MaximumMarks = 100
            };

            // Add to context
            _context.Classes.Add(studentClass);
            _context.Students.Add(student);
            _context.Exams.Add(exam);
            _context.Subjects.AddRange(subject1, subject2);
            _context.Marks.AddRange(marks1, marks2);

            await _context.SaveChangesAsync(cancellationToken);
            return $"Dummy data created for student: {student.Name}";
        }
    }
}
