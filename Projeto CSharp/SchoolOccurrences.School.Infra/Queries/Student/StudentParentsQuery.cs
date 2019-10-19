using System;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;

namespace SchoolOccurrences.School.Infra.Queries.Student
{
    public class StudentParentsQuery : IQuery
    {
        public Guid Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int Serie { get; set; }
        public string Grade { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleDocumentNumber { get; set; }
        public EDocumentType Type { get; set; }
        public EFamilyType EFamilyType { get; set; }
        public string ResponsibleTelephone { get; set; }
        public string ResponsibleEmail { get; set; }
        public Guid ResponsibleId { get; set; }
    }
}
