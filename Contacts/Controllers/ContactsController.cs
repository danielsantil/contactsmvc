using Contacts.Filters;
using Contacts.Models;
using Contacts.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    [ModelValidationFilter]
    public class ContactsController : Controller
    {
        private readonly IRepository<Contact> _repository;

        public ContactsController(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IEnumerable<Contact> contacts = await _repository.GetAll();

            return Ok(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            Contact contact = await _repository.Get(x => x.Id == id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact model)
        {
            await _repository.Insert(model);
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Contact model)
        {
            await _repository.Update(model);
            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            Contact contact = await _repository.Get(x => x.Id == id);
            if (contact == null)
                return NotFound();

            await _repository.Delete(contact);
            return Ok();
        }
    }
}