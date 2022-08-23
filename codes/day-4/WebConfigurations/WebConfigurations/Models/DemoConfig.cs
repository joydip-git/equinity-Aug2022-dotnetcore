using System.ComponentModel.DataAnnotations;

namespace WebConfigurations.Models
{
    public class DemoConfig : IValidatableObject
    {
        public string Key1 { get; set; }
        public int Key2 { get; set; }
        private List<ValidationResult> _errors;

        public DemoConfig()
        {
            _errors = new List<ValidationResult>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var demoConfigInstance = validationContext.ObjectInstance as DemoConfig;
            if (demoConfigInstance?.Key2 < 0 || demoConfigInstance?.Key2 > 10)
            {
                _errors.Add(new ValidationResult("key2 value should be between 0 and 10"));
            }
            return _errors;
        }
    }
}
