using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BDapp.utilities
{
    public static class HTMLHandler
    {
        /// <summary>
        /// Téléchargement de la page web
        /// </summary>
        /// <returns></returns>
        public static string downloadSourcePage(string url)
        {
            string htmlPage = null;
            using (WebClient client = new WebClient())
            {
                htmlPage = client.DownloadString(url);
            }
            return htmlPage;
        }
    }
}
