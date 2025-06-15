using StudentReportCard.Domain.BaseEntities;
using System.Security.Claims;

namespace StudentReportCard.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public Guid ClassId { get; set; }
        public StudentClass Class { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
