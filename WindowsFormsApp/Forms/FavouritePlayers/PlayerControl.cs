using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp.Forms.FavouritePlayers
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.StandardClick, true);

            this.tsMoveTo.Text = Program.GetLocalizedString("Move");
            this.tsToFavorites.Text = Program.GetLocalizedString("toFavorites");
            this.tsToOther.Text = Program.GetLocalizedString("toOthers");
            this.tsAddPicture.Text = Program.GetLocalizedString("AddPicture");
        }

        internal delegate void UpdateImage(Image image, long shirtNumber);
        internal event UpdateImage updatePlayers;

        public Player playerData;
        public bool _isSelected = false;

        public PlayerControl(Player playerData)
        {
            this.playerData = playerData;
            lbName.Text = SplitName();
            lbNumber.Text = playerData.ShirtNumber.ToString();
            cbCaptain.Checked = playerData.Captain;
        }

        private string SplitName()
        {
            var capitalized = playerData.Name.ToLower();
            var split = capitalized.Split(' ');

            string firstline = string.Join(' ', split.SkipLast(1));
            string secondline = split.Last();

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return $"{textInfo.ToTitleCase(firstline)}\n{textInfo.ToTitleCase(secondline)}";
        }

        public object PlayerData { get; }

        public void SetPlayerImage(Image playerPortrait)
        {
            this.pbPlayerPortrait.Image = playerPortrait;
        }

        public void SetSelectionStatus(bool value)
        {
            _isSelected = value;
            cbSelected.Checked = value;
            BackColor = _isSelected ? Color.FromArgb(104, 104, 104) : SystemColors.Control;
        }

        internal void TriggerMouseDown(MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        internal void SetFavoriteStatus(bool value)
        {
            playerData.Favorite = value;
        }

        private void tsToFavorites_Click(object sender, EventArgs e)
        {
            FavouritePlayers parentForm = this.FindForm() as FavouritePlayers;
            parentForm.goingTo = parentForm.flFavourites;
            parentForm.departedFrom = this.Parent as FlowLayoutPanel;
            SetSelectionStatus(true);
            parentForm.MoveSelectedControls();
        }

        private void tsToOther_Click(object sender, EventArgs e)
        {
            FavouritePlayers parentForm = this.FindForm() as FavouritePlayers;
            parentForm.goingTo = parentForm.flOthers;
            parentForm.departedFrom = this.Parent as FlowLayoutPanel;
            SetSelectionStatus(true);
            parentForm.MoveSelectedControls();
        }

        private void cbCaptain_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectionStatus(cbSelected.Checked);
        }

        private void tsAddPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                // little time, bad code
                try
                {
                    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    var downloads = home + "\\Downloads";
                    fileDialog.InitialDirectory = downloads;
                    fileDialog.Filter = $"{Program.GetLocalizedString("ImageFiles")} (*.png, *.jpg, *jpeg)|*.jp*g;*.png|{Program.GetLocalizedString("Allfiles")} (*.*)|*.*";
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationDirectory = Program.userSettings.GenderedRepresentationFilePath() + Program.LastTeam.FifaCode;
                        if (!Directory.Exists(destinationDirectory))
                        {
                            Directory.CreateDirectory(destinationDirectory);
                        }
                        string destinationFile = destinationDirectory + $"/{playerData.ShirtNumber}.{fileDialog.FileName.Split('.').Last()}";
                        File.Copy(fileDialog.FileName, destinationFile, true);
                        this.playerData.PortraitPath = destinationFile;
                        Image image = Image.FromFile(destinationFile);
                        updatePlayers?.Invoke(image, playerData.ShirtNumber);
                        pbPlayerPortrait.Image = image;
                        (this.FindForm() as FavouritePlayers).SaveState();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Program.GetLocalizedString("IconSetError"));
                }
            }
        }
    }
}
