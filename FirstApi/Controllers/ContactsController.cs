using FirstApi.Context;
using FirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = addContactRequest.Name,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult> UpdateContact(Guid Id, UpdateContact updateContact)
        {
            var contact = await dbContext.Contacts.FindAsync (Id);         
            if (contact == null)
            {
                return NotFound();
            }
            contact.Name = updateContact.Name;
            contact.Email = updateContact.Email;
            contact.Phone = updateContact.Phone;

            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetContact(Guid Id)
        {
            var contact = await dbContext.Contacts.FindAsync(Id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> DeleteContact(Guid Id)
        {
            var contact = await dbContext.Contacts.FindAsync(Id);
            if (contact == null)
            {
                return NotFound();
            }
            dbContext.Remove(contact);
            await dbContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}
