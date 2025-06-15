using StudentReportCard.Domain.BaseEntities;

namespace StudentReportCard.Domain.Entities
{
    public class StudentClass : BaseEntity
    {
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string AcademicYear { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
