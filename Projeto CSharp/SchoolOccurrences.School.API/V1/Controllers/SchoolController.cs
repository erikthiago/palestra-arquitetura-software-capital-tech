using Microsoft.AspNetCore.Mvc;
using SchoolOccurrences.School.Domain.Commands.School;
using SchoolOccurrences.School.Domain.Handlers;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.Shared.Commons.Commands;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;
using System.Collections;
using System.Net;

namespace SchoolOccurrences.School.API.V1.Controllers
{
    [Produces("application/json")]
    [Route("api/School")]
    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _repository;
        private readonly SchoolCommandHandler _handler;

        public SchoolController(ISchoolRepository repository, SchoolCommandHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        
        // GET: api/School
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetAll()
        {
            var retorno = _repository.GetAllSchools();
            return retorno;
        }

        // GET: api/School/students
        [HttpGet("students", Name = "GetSchoolStudents")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetSchoolStudents()
        {
            var retorno = _repository.GetSchoolStudents();
            return retorno;
        }

        // GET: api/School/5
        [HttpGet("getbyid/{id}", Name = "GetById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public Domain.Entities.School GetById(Guid id)
        {
            var school = _repository.GetById(id);
            return school;
        }

        // GET: api/School/{documentNumber}
        [HttpGet("{documentNumber}", Name = "GetByDocument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IQuery GetByDocument(string documentNumber)
        {
            var school = _repository.GetSchool(documentNumber);
            return school;
        }

        // POST: api/School
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Post([FromBody]CreateSchoolCommand value)
        {
            var result = (CommandResult)_handler.Handle(value);
            return result;
        }
        
        // PUT: api/School/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Put([FromBody]UpdateSchoolCommand value)
        {
            var result = (CommandResult)_handler.Handle(value);
            return result;
        }
        
        // DELETE: api/School/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Delete(Guid id)
        {
            DeleteSchoolCommand command = new DeleteSchoolCommand();
            command.Id = id;
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }
    }
}
