using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Validation.Models
{
    public class DateComesLaterAttribute : ValidationAttribute, IClientValidatable
    {
        public const string DefaultErrorMessage = "'{0}' must be after '{1}'";

        private readonly string _otherDateProperty;

        public DateComesLaterAttribute(string otherDateProperty)
        {
            _otherDateProperty = otherDateProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = validationContext.ObjectType;

            var earlierDate = (DateTime?)type.GetProperty(_otherDateProperty).GetValue(instance, null);
            var date = (DateTime?)value;

            if (date > earlierDate)
                return ValidationResult.Success;

            string errorMessage = GetErrorMessage(validationContext.ObjectType, validationContext.DisplayName);

            return new ValidationResult(errorMessage);
        }

        private string GetErrorMessage(Type containerType, string displayName)
        {
            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForProperty(null, containerType,
                                                                                           _otherDateProperty);
            var otherDisplayName = metadata.GetDisplayName();
            return ErrorMessage ?? string.Format(DefaultErrorMessage, displayName, otherDisplayName);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                           {
                               ErrorMessage = GetErrorMessage(metadata.ContainerType, metadata.GetDisplayName()) + " (via client validation)",
                               ValidationType = "later",
                           };

            rule.ValidationParameters.Add("other", "*." + _otherDateProperty);

            yield return rule;
        }
    }
}