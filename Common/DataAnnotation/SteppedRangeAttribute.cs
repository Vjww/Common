using System.ComponentModel.DataAnnotations;

namespace Common.DataAnnotation
{
    public class SteppedRangeAttribute : RangeAttribute
    {
        private readonly int _multiplier;

        public SteppedRangeAttribute(int minimum, int maximum, int multiplier) : base(minimum, maximum)
        {
            _multiplier = multiplier;
        }

        public override bool IsValid(object value)
        {
            var baseResult = base.IsValid(value);

            var valueType = value.GetType();
            if (valueType != typeof(int))
            {
                return baseResult;
            }

            // If int value has a remainder
            if ((int)value % _multiplier != 0)
            {
                // Invalid step
                return false;
            }

            // Valid step
            return true;
        }
    }
}
