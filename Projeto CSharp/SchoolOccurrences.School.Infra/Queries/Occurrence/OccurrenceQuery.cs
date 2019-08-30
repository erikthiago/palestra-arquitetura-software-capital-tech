using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;

namespace SchoolOccurrences.School.Infra.Queries.Occurrence
{
    public class OccurrenceQuery : IQuery
    {
        public Guid Id { get; set; }
        public EOccurrenceType OccurrenceType { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }
        public EOccurrenceStatus OccurrenceStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
