using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {

        public static string BASE_DIR = Path.Join(Path.GetTempPath() + "OOPNET-LC");
        public static string USER { get { return BASE_DIR + "\\user.json"; } }
        public static string REPRESENTATION { get { return BASE_DIR + "\\rep.json"; } }
        public static string CACHE { get { return BASE_DIR + "\\cache\\"; } }
        public static string FEMALE_TEAMS { get { return BASE_DIR + "\\f\\"; } }
        public static string MALE_TEAMS { get { return BASE_DIR + "\\m\\"; } }
        // public static UserSettings userSettings { get; set; }
        public static Team LastTeam { get; set; }
        public static Localiser Localizer { get; private set; }
        internal static bool firstLaunch = true;
        internal static string defaultLocale = "en";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Settings());
        }
    }
}
