using System.Collections.Generic;
using System.Net.Http;

namespace HackBulgaria_2_A_Simple_Logger.Loggers
{
    class HttpLogger : BaseLogger
    {
        public string Url { get; set; }
        
        public HttpLogger() {}

        public HttpLogger(string url)
        {
            Url = url;
        }

        public override void Log(int level, string message)
        {
            var logMessage = GenerateLogMessageString(level, message);
            
            var client = new HttpClient();
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("log_message", logMessage)
            };
            var content = new FormUrlEncodedContent(pairs);

            var response = client.PostAsync(Url, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                //TODO: needs to be specified
            }
            
        }
    }
}
