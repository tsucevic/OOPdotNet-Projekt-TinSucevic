using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Localization
{
    class Localiser
    {
        JObject locales;
        string currentLocale;
        public Localiser(string locale)
        {
            var jsonData = File.ReadAllText("strings.json");
            locales = JObject.Parse(jsonData);
            currentLocale = locale;
        }
        public string Resource(string request)
        {
            return Resource(request, currentLocale);
        }
        public string Resource(string request, string locale)
        {
            try
            {
                return locales[request][locale].ToString();
            }
            catch (Exception)
            {
                return "MISSING STRING";
            }
        }
    }
}
