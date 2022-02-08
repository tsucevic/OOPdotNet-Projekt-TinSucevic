
namespace WindowsFormsApp.Forms.FavouritePlayers
{
    partial class FavouritePlayers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlMain = new System.Windows.Forms.TableLayoutPanel();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuRankings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuPlayerRankings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMPRGoals = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMPRYellowCards = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuSpectatorRankings = new System.Windows.Forms.ToolStripMenuItem();
            this.flFavourites = new System.Windows.Forms.FlowLayoutPanel();
            this.flOthers = new System.Windows.Forms.FlowLayoutPanel();
            this.tlMain.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMain
            // 
            this.tlMain.ColumnCount = 2;
            this.tlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.375F));
            this.tlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.625F));
            this.tlMain.Controls.Add(this.msMenu, 0, 0);
            this.tlMain.Controls.Add(this.flFavourites, 0, 1);
            this.tlMain.Controls.Add(this.flOthers, 1, 1);
            this.tlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMain.Location = new System.Drawing.Point(0, 0);
            this.tlMain.Name = "tlMain";
            this.tlMain.RowCount = 2;
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.04782F));
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.95218F));
            this.tlMain.Size = new System.Drawing.Size(1010, 711);
            this.tlMain.TabIndex = 0;
            // 
            // msMenu
            // 
            this.tlMain.SetColumnSpan(this.msMenu, 2);
            this.msMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuSettings,
            this.tsMenuRankings});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1010, 43);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsMenuSettings
            // 
            this.tsMenuSettings.Name = "tsMenuSettings";
            this.tsMenuSettings.Size = new System.Drawing.Size(66, 39);
            this.tsMenuSettings.Text = "Postavke";
            this.tsMenuSettings.Click += new System.EventHandler(this.tsMenuSettings_Click);
            // 
            // tsMenuRankings
            // 
            this.tsMenuRankings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuPlayerRankings,
            this.tsMenuSpectatorRankings});
            this.tsMenuRankings.Enabled = false;
            this.tsMenuRankings.Name = "tsMenuRankings";
            this.tsMenuRankings.Size = new System.Drawing.Size(70, 39);
            this.tsMenuRankings.Text = "Rang liste";
            // 
            // tsMenuPlayerRankings
            // 
            this.tsMenuPlayerRankings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMPRGoals,
            this.tsMPRYellowCards});
            this.tsMenuPlayerRankings.Name = "tsMenuPlayerRankings";
            this.tsMenuPlayerRankings.Size = new System.Drawing.Size(195, 22);
            this.tsMenuPlayerRankings.Text = "Igraci";
            // 
            // tsMPRGoals
            // 
            this.tsMPRGoals.Name = "tsMPRGoals";
            this.tsMPRGoals.Size = new System.Drawing.Size(177, 22);
            this.tsMPRGoals.Text = "Br Zabijenih Golova";
            // 
            // tsMPRYellowCards
            // 
            this.tsMPRYellowCards.Name = "tsMPRYellowCards";
            this.tsMPRYellowCards.Size = new System.Drawing.Size(177, 22);
            this.tsMPRYellowCards.Text = "Br Zutih Kartona";
            // 
            // tsMenuSpectatorRankings
            // 
            this.tsMenuSpectatorRankings.Name = "tsMenuSpectatorRankings";
            this.tsMenuSpectatorRankings.Size = new System.Drawing.Size(195, 22);
            this.tsMenuSpectatorRankings.Text = "Posjetitelji Po Utakmici";
            // 
            // flFavourites
            // 
            this.flFavourites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flFavourites.Location = new System.Drawing.Point(3, 46);
            this.flFavourites.Name = "flFavourites";
            this.flFavourites.Size = new System.Drawing.Size(118, 662);
            this.flFavourites.TabIndex = 1;
            // 
            // flOthers
            // 
            this.flOthers.AllowDrop = true;
            this.flOthers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flOthers.Location = new System.Drawing.Point(127, 46);
            this.flOthers.Name = "flOthers";
            this.flOthers.Size = new System.Drawing.Size(880, 662);
            this.flOthers.TabIndex = 2;
            this.flOthers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flOthers_DragDrop);
            this.flOthers.DragOver += new System.Windows.Forms.DragEventHandler(this.flOthers_DragOver);
            // 
            // FavouritePlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 711);
            this.Controls.Add(this.tlMain);
            this.MainMenuStrip = this.msMenu;
            this.Name = "FavouritePlayers";
            this.Text = "FavouritePlayers";
            this.Load += new System.EventHandler(this.FavouritePlayers_LoadAsync);
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMain;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRankings;
        private System.Windows.Forms.ToolStripMenuItem tsMenuPlayerRankings;
        private System.Windows.Forms.ToolStripMenuItem tsMPRGoals;
        private System.Windows.Forms.ToolStripMenuItem tsMPRYellowCards;
        private System.Windows.Forms.ToolStripMenuItem tsMenuSpectatorRankings;
        internal System.Windows.Forms.FlowLayoutPanel flFavourites;
        internal System.Windows.Forms.FlowLayoutPanel flOthers;
    }
}