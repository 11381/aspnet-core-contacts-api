using System.Collections.Generic;

namespace Backend.Models
{
    public interface IContactRepository
    {
        void Add(Contact item);
        IEnumerable<Contact> GetAll();
        Contact Find(string key);
        Contact Remove(string key);
        void Update(Contact item);
    }
}