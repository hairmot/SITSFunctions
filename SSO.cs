using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoLSitsFunctions
{
    public class SSO
    {
        public static string PortalLink(string baseUrl, string user, string hashKey, SSOParams parameters)
        {            
            string request = "USER=" + user.ToUpper();
            if (parameters.Container != null)
            {
                request += "&CONTAINER=" + parameters.Container;
            }
            else if (parameters.Page != null)
            {
                request += "&PAGE=" + parameters.Page;
            }          
            request += "&TABS=" + ((parameters.Tabs) ? "Y" : "N");
            request += "&CREATED=" + parameters.Created;
            string md5String = Hash.CalculateMD5Hash(request + "&" + hashKey);
            return baseUrl + request + "&HASH=" + md5String;
        }
        
        public class SSOParams
        {

            public string Page { get; set; }
            public string Container { get; set; }
            public bool Tabs { get; set; }         
            public string Created { get; set; }
            public string Expires { get; set; }
            
            public SSOParams()                    
            {
                Created = DateTime.Now.ToString("yyyyMMddHHmmss") + "00";
                Expires = "1";
                Tabs = true;
            }

        }
    }
}

    
