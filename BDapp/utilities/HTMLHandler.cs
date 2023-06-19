using System.Net;

namespace BDapp.utilities
{
    public static class HTMLHandler
    {
        /// <summary>
        /// Téléchargement de la page web
        /// </summary>
        /// <returns></returns>
        public static string DownloadSourcePage(string url)
        {
            string? htmlPage;
            using (var client = new WebClient())
            {
                htmlPage = client.DownloadString(url);
            }
            return htmlPage;
        }
    }
}
