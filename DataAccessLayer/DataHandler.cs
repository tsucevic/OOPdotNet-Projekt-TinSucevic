using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataHandler
    {
        internal static string BASE_DIR = Path.Join(Path.GetTempFileName() + "OOPNET");
        internal static string USER { get { return BASE_DIR + "\\user.json"; } }
        internal static string REPRESENTATION { get { return BASE_DIR + "\\representation.json"; } }
        public static string FEMALE_TEAMS { get { return BASE_DIR + "\\female\\"; } }
        public static string MALE_TEAMS { get { return BASE_DIR + "\\male\\"; } }
        public static string CACHE { get { return BASE_DIR + "\\cache\\"; } }

        public static void PreparePaths()
        {
            try
            {
                Directory.CreateDirectory(BASE_DIR);
                Directory.CreateDirectory(FEMALE_TEAMS);
                Directory.CreateDirectory(MALE_TEAMS);
                Directory.CreateDirectory(CACHE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void SaveUserSettings(UserSettings user)
        {
            try
            {
                File.WriteAllText(USER, user.ToString());
            }
            catch { throw; }
        }
        public static UserSettings ReadUserSettings()
        {
            try { return Fetch.FetchJsonFromFile<UserSettings>(USER); } 
            catch { throw; }
        }
        public static void WipeUserSettings() => File.Delete(USER);
        public static void SaveRepresentation(Team team)
        {
            try
            {
                File.WriteAllText(REPRESENTATION, team.ToString());
            }
            catch { throw; }
        }
        public static Team ReadRepresentation()
        {
            try { return Fetch.FetchJsonFromFile<Team>(REPRESENTATION); } 
            catch { throw; }
        }
        public static void WipeRepresentation() => File.Delete(REPRESENTATION);

        public static void DeleteAllLocalFiles() => Directory.Delete(BASE_DIR, true);
    }
}
