using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UoLSitsFunctions
{
    public class StuTalk
    {
        static public string Request(StuTalkFunction function, string url, string user, string WSO_PassKeyText, string parameters, string indata, string options = "", string delimiter = "~")
        {     
            string passkey = Hash.CalculateMD5Hash(user + WSO_PassKeyText + "|" + user);
            string md5 = Hash.CalculateMD5Hash(user + passkey + "|SITS|" + delimiter + options + FunctionTranslation[(int)function] + "|VISION|" + parameters + indata);
            return GetRequest(url + "USER=" + user + "&PASSKEY=" + passkey +
                     "&DELIMITER=" + delimiter + "&PARAMETERS=" + parameters + "&INDATA=" + indata.Replace("+","%2B") + "&FUNCTION=" + FunctionTranslation[(int)function] + "&MD5=" + md5);
        }

        static private string GetRequest(string request)
        {
            string result = "";
            try
            {
                WebRequest req = WebRequest.Create(request);
                Stream objStream;
                objStream = req.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = "";
                int i = 0;
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        result += sLine;
                }
            }
            catch (Exception e)
            {
                result += e.Message;
            }
            return result;
        }

        public enum StuTalkFunction { GET_FLD = 0, GET_LIST = 1};

        static public string[] FunctionTranslation = new string[] { "GET_FLD", "GET_LIST" };
    }
}
