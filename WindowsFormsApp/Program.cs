using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Forms.Settings;
using WindowsFormsApp.Forms.FavouriteRepresentation;

namespace WindowsFormsApp
{
    static class Program
    {

        
        public static UserSettings userSettings { get; set; }
        public static Team LastTeam { get; set; }
        public static Localiser Localizer { get; private set; }
        internal static bool isFirstLaunch = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DataHandler.PreparePaths();
                if (!FirstLaunch())
                {
                    PrepareLocale();
                    Application.Run(new Settings());
                    isFirstLaunch = false;
                }
                UpdateLocale();
                ReadLastSavedTeam();
                Application.Run(new FavouriteRepresentation());
                Application.Run(new FavouritePlayers());

                //For testing only
                DataHandler.DeleteAllLocalFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Unrecoverrable error was detected...");

                DataHandler.WipeUserSettings();
                Application.Exit();
            }
        }

        internal static void ReadLastSavedTeam()
        {
            try
            {
                LastTeam = DataHandler.ReadRepresentation();
            }
            catch
            {
                LastTeam = null;
            }
        }

        internal static void UpdateUser(UserSettings user)
        {
            userSettings = user;
            UpdateLocale();
        }

        internal static void UpdateLocale()
        {
            try
            {
                switch (userSettings.SavedLanguage)
                {
                    case UserSettings.Language.Croatian:
                        Localizer = new Localiser("hr");
                        return;
                    case UserSettings.Language.English:
                        Localizer = new Localiser("en");
                        return;
                    default:
                        Localizer = new Localiser();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not initialize locales.");
            }
        }

        private static void PrepareLocale()
        {
            try
            {
                Localizer = new Localiser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not initialize locales.");
            }
        }

        private static bool FirstLaunch()
        {
            try
            {
                userSettings = DataHandler.ReadUserSettings();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static string GetLocalizedString(string req) => Localizer.Resource(req);
        
    }
}
