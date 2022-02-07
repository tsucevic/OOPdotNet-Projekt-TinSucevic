using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public static class URL
    {
        public static string F_BASE_URL = "https://worldcup.sfg.io";
        public static string M_BASE_URL = "https://world-cup-json-2018.herokuapp.com";

        public static string Matches(string baseURL)
            => baseURL + Match.ENDPOINT;

        public static string MatchesFilteredByCountry(string baseURL, string fifa_code)
            => Matches(baseURL) + Match.FILTER + fifa_code;

        public static string Teams(string baseURL)
            => baseURL + Team.ENDPOINT;
    }
}
