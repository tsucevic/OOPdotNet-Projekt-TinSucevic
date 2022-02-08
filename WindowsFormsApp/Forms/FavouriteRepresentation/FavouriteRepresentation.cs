using DataAccessLayer;
using DataAccessLayer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.Forms.FavouriteRepresentation
{
    public partial class FavouriteRepresentation : Form
    {
        private bool _dataLoaded = false;
        private bool _keepAlive = false;
        private List<Team> teams;

        public FavouriteRepresentation()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (_dataLoaded)
                try
                {
                    DataHandler.SaveRepresentation(FindSelectedRepresentation());
                    Program.ReadLastSavedTeam();
                    _keepAlive = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Program.GetLocalizedString("errorSaveRepresentation"));
                }
        }

        private Team FindSelectedRepresentation()
        {
            var fifa_code = cbRepresentation.SelectedItem.ToString()
                                                         .Split(' ')
                                                         .Last()
                                                         .Substring(1, 3);
            return teams.Find(tempTeam => tempTeam.FifaCode == fifa_code);
        }

        private async void FavouriteRepresentation_LoadAsync(object sender, EventArgs e)
        {
            btnDone.Text = Program.GetLocalizedString("Finish");
            this.Text = Program.GetLocalizedString("FavoriteRepresentation");
            this.Name = Program.GetLocalizedString("FavoriteRepresentation");
            try
            {
                List<Team> representations = null;
                lbStatus.Text = Program.GetLocalizedString("Fetching");
                string baseUrl = Program.userSettings.SavedLeague == UserSettings.League.Female ? URL.F_BASE_URL : URL.M_BASE_URL;
                string uri = DataHandler.CACHE + baseUrl.Substring(7).Replace('\\', '-').Replace('/', '-') + "@Team" + ".json";

                if (File.Exists(uri))
                {
                    representations = await Fetch.FetchJsonFromFileAsync<List<Team>>(uri);
                }
                else
                {
                    representations = await Fetch.FetchJsonFromUrlAsync<List<Team>>(URL.Teams(Program.userSettings.GenderedRepresentationUrl()));
                    File.WriteAllText(uri, JsonConvert.SerializeObject(representations));
                }

                teams = representations;
                cbRepresentation.DataSource = representations.OrderBy(tempTeam => tempTeam.FifaCode)
                                                             .Select(tempTeam => $"{tempTeam.Country} ({tempTeam.FifaCode})")
                                                             .ToList();
                _dataLoaded = true;
                lbStatus.Text = Program.GetLocalizedString("Done");
                if (Program.LastTeam != null)
                {
                    cbRepresentation.SelectedItem =
                        $"{Program.LastTeam.Country} ({Program.LastTeam.FifaCode})";
                }
            }
            catch (HttpStatusException ex)
            {
                lbStatus.Text = Program.GetLocalizedString("Aborting");
                MessageBox.Show(ex.Message, ex.GetType().Name);
                Application.Exit();
            }
            catch (JsonException ex)
            {
                lbStatus.Text = Program.GetLocalizedString("Aborting");
                MessageBox.Show(ex.Message, ex.GetType().Name);
                Application.Exit();
            }
            catch (Exception ex)
            {
                lbStatus.Text = Program.GetLocalizedString("Aborting");
                MessageBox.Show(ex.Message, ex.GetType().Name);
                Application.Exit();
            }
        }
    }
}
