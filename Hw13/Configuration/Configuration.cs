namespace Hw13.Configuration
{
    public class Configuration
    {
        public static string ConnectionString { get; set; }

        static Configuration()
        {
            ConnectionString = "Data Source=LAPTOP-CDHPQSKA\\SQLEXPRESS;Initial Catalog=Library;User ID=sa;Password=erfash3883;TrustServerCertificate=True;Encrypt=True";

        }
    }
}
