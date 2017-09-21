using System;
using System.ComponentModel.DataAnnotations;

namespace Common.DataAnnotation
{
    public class ValueMatchAttribute : ValidationAttribute
    {
        private readonly int[] _values;

        public ValueMatchAttribute(int[] values)
        {
            _values = values;
        }

        public override bool IsValid(object value)
        {
            var baseResult = base.IsValid(value);

            var valueType = value.GetType();
            if (valueType != typeof(int))
            {
                return baseResult;
            }

            for (var i = 0; i < _values.Length; i++)
            {
                // If int value is in array of values
                if ((int)value == _values[i])
                {
                    // Valid value
                    return true;
                }
            }

            // Invalid value
            return false;
        }
    }
}