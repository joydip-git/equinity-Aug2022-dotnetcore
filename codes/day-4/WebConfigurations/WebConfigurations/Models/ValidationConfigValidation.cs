using Microsoft.Extensions.Options;

namespace WebConfigurations.Models
{
    public class ValidationConfigValidation : IValidateOptions<ValidationConfig>
    {
        //public ValidationConfig ValidationConfig { get; set; }
        //public ValidationConfigValidation(IConfiguration configuration)
        //{
        //    ValidationConfig = configuration.GetSection(ValidationConfig.VALIDATION_CONFIG_SECTION_NAME).Get<ValidationConfig>();
        //}
        public ValidateOptionsResult Validate(string name, ValidationConfig options)
        {
            string? message = null;
            if (options.Key2 < 1 || options.Key2 > 10)
            {
                message = $"options.Key2 value should be between 1 and 10, current value is {options.Key2}";
            }
            if (message == null)
            {
                return ValidateOptionsResult.Success;
            }
            else
            {
                return ValidateOptionsResult.Fail(message);
            }

        }
    }
}
