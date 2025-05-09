namespace SmileLabs_BE.Configurations
{
    public class AppSettings
    {
        static AppSettings()
        {
            Configuration = new AppSettings();
        }
        public static AppSettings Configuration { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
