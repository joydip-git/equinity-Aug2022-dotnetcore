namespace WebConfigurations.Models
{
    public class ValidationConfig
    {
        public const string VALIDATION_CONFIG_SECTION_NAME = "ValidationConfig";
        
        public string Key1 { get; set; } = String.Empty;
        public int Key2 { get; set; } = 0;
        public override string ToString()
        {
            return $"{Key1},{Key2}";
        }
    }
}
