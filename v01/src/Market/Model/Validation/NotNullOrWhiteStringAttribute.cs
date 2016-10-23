using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Validation
{
    class NotNullOrWhiteStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string && !String.IsNullOrWhiteSpace((string)value);
        }
    }
}
