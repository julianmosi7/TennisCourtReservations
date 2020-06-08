using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisCourtReservations.Dtos;
using TennisCourtReservations.Services;
using TennisCourtReservationsDb;
using TennisCourtReservations.Replies;
using TennisCourtReservations;

namespace TennisCourtReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonService personService;
        
        public PersonsController(PersonService personService)
        {
            this.personService = personService;
        }

        // GET: Persons
        [HttpGet]
        public IEnumerable<PersonReplyDto> Get()
        {
            return personService.GetAll().Select(x => new PersonReplyDto().CopyPropertiesFrom(x));
        }

        // GET: Persons/5
        [HttpGet("{id}")]
        public ActionResult<PersonReplyDto> Get(int id)
        {
            Person person = personService.GetPerson(id);
            return new PersonReplyDto().CopyPropertiesFrom(person);
        }

        // POST: Persons
        [HttpPost]
        public ActionResult<PersonReplyDto> Post([FromBody] PersonDto personDto)
        {
            var person = new Person().CopyPropertiesFrom(personDto);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var personReply = personService.PostPerson(person);
            if (!personReply.Success) return BadRequest(personReply.Error);
            return Ok(new PersonReplyDto().CopyPropertiesFrom(personReply.Person));
        }

        // PUT: Persons/5
        [HttpPut("{4}")]
        public ActionResult<PersonReplyDto> Put(int id, [FromBody] PersonDto personDto)
        {
            var person = new Person().CopyPropertiesFrom(personDto);
            var personReply = personService.PutPerson(id, person);
            if (!personReply.Success) return BadRequest(personReply.Error);
            return Ok(new PersonReplyDto().CopyPropertiesFrom(personReply.Person));
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<PersonReplyDto> Delete(int id)
        {
            var personReply = personService.DeletePerson(id);
            if (!personReply.Success) return BadRequest(personReply);
            return Ok(new PersonReplyDto().CopyPropertiesFrom(personReply.Person));
        }
    }
}
