using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ValidationModelCheck : IValidationModelCheck
    {

        public void ValidateModel<TDomainModel>(TDomainModel domainModel)
        {
            ICollection<ValidationResult>
                listOfValidationResult = new List<ValidationResult>();

            ValidationContext validationContext = new ValidationContext(domainModel, null, null);

            StringBuilder stringBuilder = new StringBuilder();

            if (!Validator.TryValidateObject(domainModel, validationContext, listOfValidationResult, true))
            {
                foreach (ValidationResult validationResult in listOfValidationResult)
                {
                    stringBuilder.Append(validationResult.ErrorMessage).AppendLine();
                }
            }

            if (listOfValidationResult.Count > 0)
            {
                throw new ArgumentException(stringBuilder.ToString());
            }
        }


    }
}
