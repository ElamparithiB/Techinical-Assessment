namespace ASSESSMENTWEB.Models
{
    public class APIConfiguration
    {
        public string? _configurationstring { get; set; }
        public HttpClient client { get; set; }
        public void apiConfig()
        {
            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                _configurationstring = root.GetSection("APIServiceUrl").Value.ToString();
                client = new HttpClient();
                client.BaseAddress = new Uri(_configurationstring);
                //client.DefaultRequestHeaders.Accept.Clear();

            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
