using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace M12_Dzianis_Dukhnou.Frame
{
    public class Response
    {
        private static HttpWebResponse _response;

        public Response(HttpWebResponse response)
        {
            _response = response;
        }

        public HttpStatusCode GetStatusCode()
        {
            return _response.StatusCode;
        }

        public string GetHeaderContent(string header)
        {
            return _response.GetResponseHeader(header);
        }

        public string ReadResponseBody()
        {
            using (Stream stream = _response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public T GetJsonResponseBody<T>()
        {
            string body = ReadResponseBody();
            return JsonConvert.DeserializeObject<T>(body);
        }

        public void CloseSession()
        {
            _response.Close();
        }
    }
}
