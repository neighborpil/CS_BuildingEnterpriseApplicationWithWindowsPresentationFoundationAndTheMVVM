using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace CRM.MVVM.ViewModel
{
    public sealed class ViewModelValidator
    {
        /// <summary>
        /// Validates the field.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public static string ValidateField<T>(T entity, string field)
        {
            var validationResults = ValidationFactory.CreateValidator<T>().Validate(entity);
            var errorMessage = new StringBuilder();
            // if the entity is valid we don't go ahead
            if (validationResults.IsValid)
            {
                return errorMessage.ToString();
            }
            // verify that the errors are for this field
            var errors = validationResults.Where(x => x.Key == field);
            if (errors.Count() > 0)
            {
                foreach (var validationResult in errors)
                {
                    errorMessage.AppendLine(validationResult.Message);
                }                
            }
            // return the error message as a string with \r\n
            return errorMessage.ToString();
        }
    }
}