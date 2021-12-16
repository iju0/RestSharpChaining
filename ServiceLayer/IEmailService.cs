using DomainLayer;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IEmailService
    {
        void Add(Email email);
        void Delete(Email email);
        IEnumerable<Email> GetAll();
        Email GetById(int id);
        void Update(Email email);
    }
}