using Bogus;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Entities;
using Xunit;

namespace SchoolOccurrences.School.Tests.Entities
{
    public class StudentTests
    {
        private Faker<Student> student;
        private Student add;

        [Fact]
        public void DeveRetornarAlunoValido()
        {
            student = StudentFaker.Gerar();

            var vO = student.Generate();

            add = new Student(vO.Name, vO.Address, vO.BirthDate, vO.ETypeOfEducation, vO.AcademicYear,
                              vO.Serie, vO.Grade, vO.Shifts, vO.CalledNumber, vO.Note);

            Assert.True(add.Valid);
        }

        [Fact]
        public void DeveRetornarAlunoSerieInvalida()
        {
            student = StudentFaker.Gerar();

            var vO = student.Generate();

            add = new Student(vO.Name, vO.Address, vO.BirthDate, vO.ETypeOfEducation, vO.AcademicYear,
                              0, vO.Grade, vO.Shifts, vO.CalledNumber, vO.Note);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarAlunoTurmaInvalido()
        {
            student = StudentFaker.Gerar();

            var vO = student.Generate();

            add = new Student(vO.Name, vO.Address, vO.BirthDate, vO.ETypeOfEducation, vO.AcademicYear,
                              vO.Serie, "", vO.Shifts, vO.CalledNumber, vO.Note);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarAlunoTurmaTamanhoMaximoInvalido()
        {
            student = StudentFaker.Gerar();

            var vO = student.Generate();

            int i = 0;
            string lenght = "";

            while (i < 2)
            {
                lenght += "t";
                i++;
            }

            add = new Student(vO.Name, vO.Address, vO.BirthDate, vO.ETypeOfEducation, vO.AcademicYear,
                              vO.Serie, vO.Grade + lenght, vO.Shifts, vO.CalledNumber, vO.Note);

            Assert.True(add.Invalid);
        }
    }
}
