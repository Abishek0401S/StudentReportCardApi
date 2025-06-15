namespace StudentReportCard.Application.DTOs
{
    public class SubjectMarkDto
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int ObtainedMarks { get; set; }
        public int MaximumMarks { get; set; }
    }
}
