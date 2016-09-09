using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Backend.Models
{
    public class ContactRepository : IContactRepository
    {
        private static ConcurrentDictionary<string, Contact> _contacts =
              new ConcurrentDictionary<string, Contact>();

        public ContactRepository()
        {
            // Add(new Contact { Name = "Q" });
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values;
        }

        public void Add(Contact contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            _contacts[contact.Id] = contact;
        }

        public Contact Find(string id)
        {
            Contact contact;
            _contacts.TryGetValue(id, out contact);
            return contact;
        }

        public Contact Remove(string id)
        {
            Contact contact;
            _contacts.TryRemove(id, out contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }
    }
}