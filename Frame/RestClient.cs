using System.Net;
 
namespace M12_Dzianis_Dukhnou.Frame
{
    public static class RestClient
    {
        public static Response Execute(Request request)
        {
            return new Response((HttpWebResponse)request._executor.GetResponse());
        }
    }
}
