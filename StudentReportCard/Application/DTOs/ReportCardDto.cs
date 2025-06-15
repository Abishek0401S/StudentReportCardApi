namespace StudentReportCard.Application.DTOs
{
    public class ReportCardDto
    {
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string AcademicYear { get; set; }
        public List<ExamReportDto> Exams { get; set; }
    }
}
