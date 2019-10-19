using Flunt.Validations;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Entities;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolOccurrences.School.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Occurrence> _occurrences;
        private IList<Parent> _parents;

        //Utilizado pelo Entity
        public Student()
        {
            _occurrences = new List<Occurrence>();
            _parents = new List<Parent>();
        }

        public Student(Name name, 
            Address address, 
            DateTime birthDate, 
            ETypeOfEducation eTypeOfEducation, 
            DateTime academicYear, 
            int serie, 
            string grade, 
            EShifts shifts, 
            int calledNumber, 
            string note)
        {
            Name = name;
            _parents = new List<Parent>();
            _occurrences = new List<Occurrence>();
            Address = address;
            BirthDate = birthDate;
            ETypeOfEducation = eTypeOfEducation;
            AcademicYear = academicYear;
            Serie = serie;
            Grade = grade;
            Shifts = shifts;
            CalledNumber = calledNumber;
            Note = note;

            AddNotifications(new Contract()
             .Requires()
             //Validações da serie
             .IsTrue(Serie > 0, "Serie", StudentMessages.InvalidSerie)
             //Validações da turma
             .IsNotNullOrEmpty(Grade, "Grade", StudentMessages.IinvalidGrade)
             .HasMaxLen(Grade, 1, "Grade", string.Format(SharedMessages.MaxLength, "Grade", 1))
             );
        }

        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public DateTime BirthDate { get; private set; }
        //Verificar depois uma forma de implementar
        //public string Photo { get; set; }
        public ETypeOfEducation ETypeOfEducation { get; private set; }
        public DateTime AcademicYear { get; private set; }
        public int Serie { get; private set; }
        public string Grade { get; private set; }
        public EShifts Shifts { get; private set; }
        public int CalledNumber { get; private set; }
        public string Note { get; private set; }

        //Relacionamentos: 1 escola N alunos
        public Guid SchoolId { get; private set; }
        public School School { get; private set; }
        //Varias ocorrencias para um aluno
        public IReadOnlyCollection<Occurrence> Occurrences { get { return _occurrences.ToList(); }}
        // Varios parentes para um aluno
        public IReadOnlyCollection<Parent> Parents { get { return _parents.ToArray(); }}

        public void SetSchoolId(Guid schoolId)
        {
            SchoolId = schoolId;
        }

        public void AddParents(Parent parent)
        {
            _parents.Add(parent);
        }
    }
}
