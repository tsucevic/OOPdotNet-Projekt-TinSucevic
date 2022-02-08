using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Localization
{
    public class Localiser
    {
        internal static string defaultLocale = "en";
        JObject locales;
        string currentLocale;

        public Localiser() : this(defaultLocale) { }
       
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
