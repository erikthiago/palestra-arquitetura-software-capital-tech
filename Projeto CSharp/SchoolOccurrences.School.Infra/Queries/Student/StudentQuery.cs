using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;

namespace SchoolOccurrences.School.Infra.Queries.Student
{
    // classe usada para fazer pesquisas no banco de dados para trazer os alunos
    public class StudentQuery : IQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public EStates Abbr { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ETypeOfEducation ETypeOfEducation { get; set; }
        public DateTime AcademicYear { get; set; }
        public DateTime BirthDate { get; set; }
        public int Serie { get; set; }
        public string Grade { get; set; }
        public EShifts Shifts { get; set; }
        public int CalledNumber { get; set; }
        public string Note { get; set; }
    }
}
