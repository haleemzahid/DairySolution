namespace DairySolution.Integrations.SolvewareAPI
{
    class SolvewareApiHelper
    {
        public static readonly string BaseUrl = System.Configuration.ConfigurationManager.AppSettings["APIBaseURL"];
        public static readonly string SiteUrl = System.Configuration.ConfigurationManager.AppSettings["SiteURL"];

    }
}
