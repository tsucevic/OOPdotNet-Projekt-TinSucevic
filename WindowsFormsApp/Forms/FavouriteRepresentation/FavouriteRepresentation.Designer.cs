
namespace WindowsFormsApp.Forms.FavouriteRepresentation
{
    partial class FavouriteRepresentation
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
            this.cbRepresentation = new System.Windows.Forms.ComboBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbRepresentation
            // 
            this.cbRepresentation.FormattingEnabled = true;
            this.cbRepresentation.Location = new System.Drawing.Point(12, 12);
            this.cbRepresentation.Name = "cbRepresentation";
            this.cbRepresentation.Size = new System.Drawing.Size(331, 23);
            this.cbRepresentation.TabIndex = 0;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(255, 41);
            this.btnDone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(88, 27);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Dalje";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 41);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(82, 15);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "Nije spojeno...";
            // 
            // FavouriteRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 83);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.cbRepresentation);
            this.Name = "FavouriteRepresentation";
            this.Text = "FavouriteRepresentation";
            this.Load += new System.EventHandler(this.FavouriteRepresentation_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRepresentation;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lbStatus;
    }
}