using System;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;

namespace SchoolOccurrences.School.Infra.Queries.School
{
    // classe usada para fazer pesquisas no banco de dados para trazer a escola
    public class SchoolQuery : IQuery
    {
        public Guid Id { get ; set ; }
        public string Name { get; private set; }
        public string DocumentNumber { get; set; }
        public EDocumentType Type { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public EStates Abbr { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}
