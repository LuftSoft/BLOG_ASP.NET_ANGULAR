namespace BlogAppAPI.Services.Static
{
    public class StaticMethod
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                      .AddJsonFile("appsettings.json");                    // nạp config định dạng JSON
            var configurationroot = configBuilder.Build();
            return configurationroot;
        }
    }
}
