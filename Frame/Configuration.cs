using System.Configuration;

namespace M12_Dzianis_Dukhnou.Frame
{
    public static class Configuration
    {
        public static string GetEnviromentVar(string var) =>
            ConfigurationManager.AppSettings[var];

        public static string Url => GetEnviromentVar("APIUrl");
    }
}