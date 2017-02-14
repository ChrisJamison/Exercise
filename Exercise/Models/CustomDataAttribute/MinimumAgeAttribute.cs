using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise.Constants;

namespace Exercise.Models.CustomDataAttribute
{
    public class MinimumAgeAttribute : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            var timeSpan = DateTime.Now.Date - date;
            var year = timeSpan.TotalDays / 365;

            return year <= AppConstants.AGE_MINIMUM ? new ValidationResult(String.Format(ErrorMessages.AGE_MINIMUM, AppConstants.AGE_MINIMUM)) : ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = String.Format(ErrorMessages.AGE_MINIMUM, AppConstants.AGE_MINIMUM),
                ValidationType = "minimumage"
            };

            clientValidationRule.ValidationParameters.Add("targetage", 18);

            return new[] { clientValidationRule };
        }
    }
}