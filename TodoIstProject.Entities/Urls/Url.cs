using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoIstProject.Entities.Urls
{
    public class Url
    {
        public static string TodoIstTaskUrl => "https://api.todoist.com/rest/v2/";

        /// <summary>
        /// RequestApiUrl TodoIstProject.UI katmanından API katmanında istek atmak için tanımlandığım url
        /// </summary>
        public static string RequestApiUrl => "http://localhost:3000/api/";
    }
}
