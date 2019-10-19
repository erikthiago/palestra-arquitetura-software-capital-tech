using Microsoft.AspNetCore.Mvc;
using SchoolOccurrences.School.Domain.Commands.Occurrence;
using SchoolOccurrences.School.Domain.Handlers;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.Shared.Commons.Commands;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using System;
using System.Collections;
using System.Net;

namespace SchoolOccurrences.Occurrence.API.V1.Controllers
{
    [Produces("application/json")]
    [Route("api/Occurrence")]
    public class OccurrenceController : Controller
    {
        private readonly IOccurrenceRepository _repository;
        private readonly OccurrenceCommandHandler _handler;

        public OccurrenceController(IOccurrenceRepository repository, OccurrenceCommandHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        // GET: api/Occurrence
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetAll()
        {
            var retorno = _repository.GetAllOccurrences();
            return retorno;
        }

        // GET: api/Occurrence/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public School.Domain.Entities.Occurrence Get(Guid id)
        {
            var ocorrencia = _repository.GetById(id);
            return ocorrencia;
        }

        // GET: api/Occurrence/student
        [HttpGet("student", Name = "GetOccurrencesStudent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetStudentParents()
        {
            var retorno = _repository.GetOccurrencesStudent();
            return retorno;
        }

        // POST: api/Occurrence
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Post([FromBody]CreateOccurrenceCommand value)
        {
            var result = (CommandResult)_handler.Handle(value);
            return result;
        }

        // PUT: api/Occurrence/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Put([FromBody]UpdateOccurrenceCommand value)
        {
            var result = (CommandResult)_handler.Handle(value);
            return result;
        }

        // DELETE: api/Occurrence/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Delete(Guid id)
        {
            DeleteOccurrenceCommand command = new DeleteOccurrenceCommand();
            command.Id = id;
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }
    }
}
