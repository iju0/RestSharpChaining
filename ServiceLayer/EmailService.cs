using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EmailService : IEmailService
    {
        private IValidationModelCheck _validationModelCheck;

        public EmailService(IValidationModelCheck validationModelCheck)
        {
            _validationModelCheck = validationModelCheck;
        }

        public void Add(Email email)
        {
            _validationModelCheck.ValidateModel<Email>(email);
        }

        public void Update(Email email)
        {

        }

        public void Delete(Email email)
        {

        }

        public IEnumerable<Email> GetAll()
        {
            throw new NotImplementedException();
        }

        public Email GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
