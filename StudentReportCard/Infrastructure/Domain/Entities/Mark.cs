using StudentReportCard.Domain.BaseEntities;

namespace StudentReportCard.Domain.Entities
{
    public class Mark : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }

        public int ObtainedMarks { get; set; }
        public int MaximumMarks { get; set; }
    }
}
