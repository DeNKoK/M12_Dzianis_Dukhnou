using System.IO;
using System.Net;
using System.Reflection;

namespace M12_Dzianis_Dukhnou.Frame
{
    public class Request
    {
        private static string _url;

        public HttpWebRequest _executor;

        public Request(MethodType method, ResourseType resourse)
        {
            InitParams(resourse);
            _executor = (HttpWebRequest)WebRequest.Create(_url);
            _executor.Method = method.ToString().ToUpper();
        }

        public Request(MethodType method, ResourseType resourse, int postId)
        {
            InitParams(resourse);
            _executor = (HttpWebRequest)WebRequest.Create(_url + "/" + postId);
            _executor.Method = method.ToString().ToUpper();
        }

        private void InitParams(ResourseType resourse)
        {
            _url = UrlFactory.GetUrl(resourse);
        }

        public void CreatePostBody(string pathToFile)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _executor.ContentType = "application/json; charset=UTF-8";

            using (Stream stream = _executor.GetRequestStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    using (StreamReader reader = new StreamReader(Path.Combine(executableLocation, pathToFile)))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}
