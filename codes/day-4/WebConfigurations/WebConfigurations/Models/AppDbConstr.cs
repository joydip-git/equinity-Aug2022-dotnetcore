namespace WebConfigurations.Models
{
    public class AppDbConstr
    {
        public const string APPDB_CONSTR = "AppDbConstr";
        public string Server { get; set; } = String.Empty;
        public string Database { get; set; } = String.Empty;
        public string UserId { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public override string ToString()
        {
            return $"server={Server};database={Database};user id={UserId};password={Password}";
        }
    }
}
