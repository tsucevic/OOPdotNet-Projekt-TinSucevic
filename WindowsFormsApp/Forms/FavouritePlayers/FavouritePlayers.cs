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

namespace WindowsFormsApp.Forms.FavouritePlayers
{
    public partial class FavouritePlayers : Form
    {
        public FavouritePlayers()
        {
            InitializeComponent();
        }

        private Match match;
        private List<Player> players = new List<Player>();
        internal FlowLayoutPanel departedFrom;
        internal FlowLayoutPanel goingTo;
        private bool _dndSuccessful;

        private async void FavouritePlayers_LoadAsync(object sender, EventArgs e)
        {
            tsMenuRankings.Text = Program.GetLocalizedString("RankedList");
            tsMenuSettings.Text = Program.GetLocalizedString("Settings");
            this.Text = Program.GetLocalizedString("FavoritePlayers");
            flOthers.Controls.Clear();
            flFavourites.Controls.Clear();
            players.Clear();
            try
            {
                string path = Program.userSettings.GenderedRepresentationFilePath() + Program.LastTeam.FifaCode + ".json";
                if (File.Exists(path))
                {
                    players = await Fetch.FetchJsonFromFileAsync<List<Player>>(path);
                }
                else
                {
                    List<Match> cache_matches = null;
                    string uri = DataHandler.CACHE + Program.userSettings.GenderedRepresentationUrl().Substring(7).Replace('\\', '-').Replace('/', '-') + Program.LastTeam.FifaCode + ".json"; //checked 1
                    if (File.Exists(uri))
                    {
                        cache_matches = await Fetch.FetchJsonFromFileAsync<List<Match>>(uri);
                    }
                    else
                    {
                        cache_matches = await Fetch.FetchJsonFromUrlAsync<List<Match>>(URL.MatchesFilteredByCountry(Program.userSettings.GenderedRepresentationUrl(), Program.LastTeam.FifaCode));
                        File.WriteAllText(uri, JsonConvert.SerializeObject(cache_matches));
                    }
                    match = cache_matches.First();

                    if (match.HomeTeam.FifaCode == Program.LastTeam.FifaCode)
                    {
                        match.HomeTeamStatistics.StartingEleven.ForEach(players.Add);
                        match.HomeTeamStatistics.Substitutes.ForEach(players.Add);
                    }
                    else if (match.AwayTeam.FifaCode == Program.LastTeam.FifaCode)
                    {
                        match.AwayTeamStatistics.StartingEleven.ForEach(players.Add);
                        match.AwayTeamStatistics.Substitutes.ForEach(players.Add);
                    }
                }

                foreach (Player x in players)
                {
                    PlayerControl playerControl;
                    if (x.PortraitPath != null)
                    {
                        try
                        {
                            Image portrait = Image.FromFile(x.PortraitPath);
                            x.Portrait = portrait;
                            playerControl = PlayerControlFactory(x, portrait);
                        }
                        catch (Exception)
                        {
                            playerControl = PlayerControlFactory(x);
                        }
                    }
                    else
                    {
                        playerControl = PlayerControlFactory(x);
                    }
                    if ((bool)x.Favorite)
                    {
                        flFavourites.Controls.Add(playerControl);
                    }
                    else
                    {
                        flOthers.Controls.Add(playerControl);
                    }
                }
                SortPlayers(flFavourites);
                SortPlayers(flOthers);
            }
            catch (HttpStatusException ex)
            {
                MessageBox.Show(ex.Message, Program.GetLocalizedString("errorRequest"));
                Application.Exit();
            }
            catch (JsonException ex)
            {
                MessageBox.Show(ex.Message, Program.GetLocalizedString("errorRequest"));
                MessageBox.Show(ex.Message, Program.GetLocalizedString("errorJson"));
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
                Application.Exit();
            }
        }

        private void SortPlayers(FlowLayoutPanel playerPanel)
        {
            List<PlayerControl> playerControls = playerPanel.Controls.Cast<PlayerControl>().ToList();
            playerControls.Sort((a, b) =>
            {
                if (a.playerData.Captain || b.playerData.Captain)
                {
                    return -a.playerData.Captain.CompareTo(b.playerData.Captain);
                }
                return a.playerData.Name.Split(' ').Last().CompareTo(b.playerData.Name.Split(' ').Last());
            });
            playerPanel.Controls.Clear();
            playerControls.ForEach(playerPanel.Controls.Add);
        }

        private PlayerControl PlayerControlFactory(Player playerData)
        {
            PlayerControl playerControl = new PlayerControl(playerData);
            List<string> st = new List<string>();
            playerControl.BackColor = SystemColors.Control;
            playerControl.MouseDown += PlayerControl_MouseDown;
            playerControl.updatePlayers += PlayerControl_UpdateImage;
            playerControl.Controls.Cast<Control>()
                                  .ToList()
                                  .ForEach(x => x.MouseDown += Control_MouseDown);

            return playerControl;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            if (control.Parent is PlayerControl player)
            {
                player.TriggerMouseDown(e);
            }
        }

        private void PlayerControl_UpdateImage(Image image, long shirtNumber)
        {
            foreach (Player player in players)
            {
                if (player.ShirtNumber == shirtNumber)
                {
                    player.Portrait = image;
                }
            }
        }

        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerControl playerControl = sender as PlayerControl;
            departedFrom = playerControl.Parent as FlowLayoutPanel;

            bool isFavorite = playerControl.playerData.Favorite;
            bool wasSelected = playerControl._isSelected;
            _dndSuccessful = false;
            playerControl.SetSelectionStatus(true);
            playerControl.DoDragDrop(isFavorite, DragDropEffects.Move);
            if (_dndSuccessful)
            {
                MoveSelectedControls();
                SortPlayers(flFavourites);
                SortPlayers(flOthers);
            }
            else
            {
                playerControl.SetSelectionStatus(!wasSelected);
            }
            ResetPanels();
            SaveState();
        }

        internal void SaveState()
        {
            try
            {
                string path = Program.userSettings.GenderedRepresentationFilePath() + Program.LastTeam.FifaCode + ".json";
                File.WriteAllText(path, JsonConvert.SerializeObject(players));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Program.GetLocalizedString("PositionSaveError"));
            }
        }

        private void ResetPanels()
        {
            throw new NotImplementedException();
        }

        internal void MoveSelectedControls()
        {
            FindSelectedPlayers().ForEach(MovePlayerControl);
        }
        private void MovePlayerControl(PlayerControl movingPlayerControl)
        {
            bool favoriteStatus = (goingTo == flFavourites);
            if (favoriteStatus && flFavourites.Controls.Count > 2)
            {
                movingPlayerControl.SetSelectionStatus(false);
                return;
            }
            movingPlayerControl.SetFavoriteStatus(favoriteStatus);
            players.Find(x => x.ShirtNumber == movingPlayerControl.playerData.ShirtNumber).Favorite = favoriteStatus;
            departedFrom.Controls.Remove(movingPlayerControl);
            goingTo.Controls.Add(movingPlayerControl);
            movingPlayerControl.SetSelectionStatus(false);
        }

        private List<PlayerControl> FindSelectedPlayers()
        {
            List<PlayerControl> controls = new List<PlayerControl>();
            flOthers.Controls.Cast<PlayerControl>()
                                   .ToList()
                                   .FindAll(x => x._isSelected)
                                   .ForEach(controls.Add);
            flFavourites.Controls.Cast<PlayerControl>()
                                   .ToList()
                                   .FindAll(x => x._isSelected)
                                   .ForEach(controls.Add);
            return controls;
        }

        private PlayerControl PlayerControlFactory(Player playerData, Image portrait)
        {
            var playerControl = PlayerControlFactory(playerData);
            playerControl.SetPlayerImage(portrait);
            return playerControl;
        }

        private void flOthers_DragOver(object sender, DragEventArgs e)
        {

        }

        private void flOthers_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void tsMenuSettings_Click(object sender, EventArgs e)
        {
            Settings.Settings settings = new Settings.Settings();
            settings.ShowDialog();
            this.OnLoad(new EventArgs());
        }
    }
}
