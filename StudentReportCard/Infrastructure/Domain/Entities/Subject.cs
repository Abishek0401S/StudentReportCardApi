using StudentReportCard.Domain.BaseEntities;

namespace StudentReportCard.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
