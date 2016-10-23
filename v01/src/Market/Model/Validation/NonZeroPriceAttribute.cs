using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class NonZeroPriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is float && (float)value > 0;
        }
    }
}
