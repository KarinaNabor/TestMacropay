using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestContactsApi.Data;
using TestContactsApi.Models;
using TestContactsApi.Services.Contracts;

namespace TestContactsApi.Services
{
    public class ContactsServices:IContactsServices
    {
        private readonly ContactsContext _contactsContext;
        public ContactsServices(ContactsContext contactsContext)
        {
            this._contactsContext = contactsContext;
        }
        public async Task<Contact> GetContactById(int id)
        {
            return await _contactsContext.Contacts
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x => x.ContactId.Equals(id));
        }

        public void DeleteContactById(int id)
        {
            Contact contact = this._contactsContext.Contacts
                .FirstOrDefault(x => x.ContactId.Equals(id));

            if(contact == null)
            {
                throw new Exception("204");
            }

            this._contactsContext.Contacts.Remove(contact);
            this.Save();
        }
        public async Task<IEnumerable<Contact>> GetContactByPattern(string pattern)
        {
            return await _contactsContext.Contacts
                .Include(x => x.Addresses)
                .Where(x=>x.Name.ToLower().Contains(pattern.ToLower())).ToListAsync();
        }
        public void Save()
        {
            this._contactsContext.SaveChanges();
        }
    }
}
