using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;

namespace SchoolOccurrences.School.Infra.Queries.School
{
    // Fazer a pesquisa no banco para retornar os alunos da escola
    public class SchoolStudentsQuery : IQuery
    {
        public Guid Id { get; set; }
        public string SchoolName { get; private set; }
        public string SchoolDocumentNumber { get; set; }
        public EDocumentType SchoolTypeDocument { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public ETypeOfEducation StudentETypeOfEducation { get; set; }
        public DateTime StudentAcademicYear { get; set; }
        public int StudentSerie { get; set; }
        public string StudentGrade { get; set; }
        public EShifts StudentShifts { get; set; }
        public int STudentCalledNumber { get; set; }
    }
}
