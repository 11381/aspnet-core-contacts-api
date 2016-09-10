using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        public IContactRepository Contacts { get; set; }

        public ContactController(IContactRepository contacts)
        {
            Contacts = contacts;
        }

        public IEnumerable<Contact> GetAll()
        {
            return Contacts.GetAll();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(string id)
        {
            var contact = Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return new ObjectResult(contact);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            Contacts.Add(contact);
            return CreatedAtRoute("GetContact", new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contact contact)
        {
            if (contact == null || contact.Id != id)
            {
                return BadRequest();
            }

            var existing = Contacts.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            Contacts.Update(contact);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contact = Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            Contacts.Remove(id);
            return new NoContentResult();
        }
    }
}