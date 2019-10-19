using Microsoft.AspNetCore.Mvc;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.School.Domain.Handlers;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.Shared.Commons.Commands;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;
using System.Collections;
using System.Net;

namespace SchoolOccurrences.Student.API.V1.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentCommandHandler _handler;

        public StudentController(IStudentRepository studentRepository, StudentCommandHandler handler)
        {
            _studentRepository = studentRepository;
            _handler = handler;
        }

        // GET: api/Student
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetAll()
        {
            var retorno = _studentRepository.GetAllStudents();
            return retorno;
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public School.Domain.Entities.Student GetById(Guid id)
        {
            var student = _studentRepository.GetById(id);
            return student;
        }

        // GET: api/Student/name/{studentName}
        [HttpGet("name/{studentName}", Name = "GetByName")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IQuery GetByName(string studentName)
        {
            var student = _studentRepository.GetStudent(studentName);
            return student;
        } 

        // GET: api/Student/parents
        [HttpGet("parents", Name = "GetStudentParents")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetStudentParents()
        {
            var retorno = _studentRepository.GetStudentParents();
            return retorno;
        }

        // POST: api/Student
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Post([FromBody]CreateStudentCommand value)
        {
            var result = (CommandResult)_handler.Handle(value);
            return result;
        }
        
        // PUT: api/Student/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Put([FromBody]UpdateStudentCommand value)
        {
            var result = (CommandResult)_handler.Handle(value);
            return result;
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Delete(Guid id)
        {
            DeleteStudentCommand command = new DeleteStudentCommand();
            command.Id = id;
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }
    }
}
