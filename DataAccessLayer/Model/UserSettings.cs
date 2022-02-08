using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class UserSettings
    {
        public UserSettings(League savedLeague, Language savedLanguage)
        {
            SavedLeague = savedLeague;
            SavedLanguage = savedLanguage;
        }

        public League SavedLeague { get; set; }
        public Language SavedLanguage { get; set; }

        public enum League
        {
            Female = 0,
            Male = 1
        }
        public enum Language
        {
            English = 0,
            Croatian = 1
        }

        public string GenderedRepresentationUrl()
        {
            switch (SavedLeague)
            {
                case League.Female:
                    return URL.F_BASE_URL;
                case League.Male:
                    return URL.M_BASE_URL;
                default:
                    throw new Exception("Unsupported league selected");
            }
        }

        public string GenderedRepresentationFilePath()
        {
            switch (SavedLeague)
            {
                case League.Female:
                    return DataHandler.FEMALE_TEAMS;
                case League.Male:
                    return DataHandler.MALE_TEAMS;
                default:
                    throw new Exception("Unsupported league selected");
            }
        }
    }
}
