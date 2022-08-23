using System.ComponentModel.DataAnnotations;

namespace WebConfigurations.Models
{
    public class SampleConfig
    {
        public const string SAMPLE_CONFIG_SECTION_NAME = "SampleConfig";

        [RegularExpression(@"^[a-zA-Z''_'\s]")]
        public string Key1 { get; set; } = String.Empty;

        [Range(0, 10, ErrorMessage = "Value should be between 1 and 10")]
        public int Key2 { get; set; } = 0;
        public override string ToString()
        {
            return $"{Key1},{Key2}";
        }
    }
}
