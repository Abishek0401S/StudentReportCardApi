namespace StudentReportCard.Application.DTOs
{
    public class ExamReportDto
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public List<SubjectMarkDto> Subjects { get; set; }
        public int TotalObtained { get; set; }
        public int TotalMaximum { get; set; }
        public double Percentage { get; set; }
    }
}
