
namespace WindowsFormsApp.Forms.FavouritePlayers
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnIconPanel = new System.Windows.Forms.Panel();
            this.pbPlayerPortrait = new System.Windows.Forms.PictureBox();
            this.cbSelected = new System.Windows.Forms.CheckBox();
            this.cbCaptain = new System.Windows.Forms.CheckBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.cmMove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToOther = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.pnIconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPortrait)).BeginInit();
            this.cmMove.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnIconPanel
            // 
            this.pnIconPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnIconPanel.Controls.Add(this.cbSelected);
            this.pnIconPanel.Controls.Add(this.pbPlayerPortrait);
            this.pnIconPanel.Location = new System.Drawing.Point(0, 0);
            this.pnIconPanel.Name = "pnIconPanel";
            this.pnIconPanel.Size = new System.Drawing.Size(169, 179);
            this.pnIconPanel.TabIndex = 0;
            // 
            // pbPlayerPortrait
            // 
            this.pbPlayerPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPlayerPortrait.ErrorImage = global::WindowsFormsApp.Properties.Resources.defaultimg;
            this.pbPlayerPortrait.InitialImage = global::WindowsFormsApp.Properties.Resources.defaultimg;
            this.pbPlayerPortrait.Location = new System.Drawing.Point(0, 0);
            this.pbPlayerPortrait.Name = "pbPlayerPortrait";
            this.pbPlayerPortrait.Size = new System.Drawing.Size(169, 179);
            this.pbPlayerPortrait.TabIndex = 0;
            this.pbPlayerPortrait.TabStop = false;
            // 
            // cbSelected
            // 
            this.cbSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSelected.AutoSize = true;
            this.cbSelected.Location = new System.Drawing.Point(151, 4);
            this.cbSelected.Name = "cbSelected";
            this.cbSelected.Size = new System.Drawing.Size(15, 14);
            this.cbSelected.TabIndex = 1;
            this.cbSelected.UseVisualStyleBackColor = true;
            // 
            // cbCaptain
            // 
            this.cbCaptain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbCaptain.AutoSize = true;
            this.cbCaptain.Location = new System.Drawing.Point(7, 200);
            this.cbCaptain.Name = "cbCaptain";
            this.cbCaptain.Size = new System.Drawing.Size(69, 19);
            this.cbCaptain.TabIndex = 1;
            this.cbCaptain.Text = "Kapetan";
            this.cbCaptain.UseVisualStyleBackColor = true;
            this.cbCaptain.CheckedChanged += new System.EventHandler(this.cbCaptain_CheckedChanged);
            // 
            // lbNumber
            // 
            this.lbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(4, 182);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(19, 15);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "99";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(29, 182);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(58, 15);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Lepi Ajaki";
            // 
            // cmMove
            // 
            this.cmMove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMoveTo,
            this.tsAddPicture});
            this.cmMove.Name = "cmMove";
            this.cmMove.Size = new System.Drawing.Size(181, 70);
            // 
            // tsMoveTo
            // 
            this.tsMoveTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsToFavorites,
            this.tsToOther});
            this.tsMoveTo.Name = "tsMoveTo";
            this.tsMoveTo.Size = new System.Drawing.Size(180, 22);
            this.tsMoveTo.Text = "Pomakni";
            // 
            // tsToFavorites
            // 
            this.tsToFavorites.Name = "tsToFavorites";
            this.tsToFavorites.Size = new System.Drawing.Size(180, 22);
            this.tsToFavorites.Text = "Dodaj u favorite";
            this.tsToFavorites.Click += new System.EventHandler(this.tsToFavorites_Click);
            // 
            // tsToOther
            // 
            this.tsToOther.Name = "tsToOther";
            this.tsToOther.Size = new System.Drawing.Size(180, 22);
            this.tsToOther.Text = "Dodaj u ostale";
            this.tsToOther.Click += new System.EventHandler(this.tsToOther_Click);
            // 
            // tsAddPicture
            // 
            this.tsAddPicture.Name = "tsAddPicture";
            this.tsAddPicture.Size = new System.Drawing.Size(180, 22);
            this.tsAddPicture.Text = "Dodaj sliku";
            this.tsAddPicture.Click += new System.EventHandler(this.tsAddPicture_Click);
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.cbCaptain);
            this.Controls.Add(this.pnIconPanel);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(169, 247);
            this.pnIconPanel.ResumeLayout(false);
            this.pnIconPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPortrait)).EndInit();
            this.cmMove.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnIconPanel;
        private System.Windows.Forms.PictureBox pbPlayerPortrait;
        private System.Windows.Forms.CheckBox cbSelected;
        private System.Windows.Forms.CheckBox cbCaptain;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.ContextMenuStrip cmMove;
        private System.Windows.Forms.ToolStripMenuItem tsMoveTo;
        private System.Windows.Forms.ToolStripMenuItem tsToFavorites;
        private System.Windows.Forms.ToolStripMenuItem tsToOther;
        private System.Windows.Forms.ToolStripMenuItem tsAddPicture;
    }
}
