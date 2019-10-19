using System;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;

namespace SchoolOccurrences.School.Infra.Queries.Occurrence
{
    class OccurrenceStudentQuery : IQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Serie { get; set; }
        public string Grade { get; set; }
        public EOccurrenceType OccurrenceType { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }
        public EOccurrenceStatus OccurrenceStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
