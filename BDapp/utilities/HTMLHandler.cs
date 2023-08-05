namespace BDapp.utilities
{
    public static class HTMLHandler
    {
        /// <summary>
        /// Téléchargement de la page web
        /// </summary>
        /// <returns></returns>
        public static async Task<string> DownloadSourcePage(string url)
        {
            string htmlPage;
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync(url);
            }
            return htmlPage;
        }
    }
}
