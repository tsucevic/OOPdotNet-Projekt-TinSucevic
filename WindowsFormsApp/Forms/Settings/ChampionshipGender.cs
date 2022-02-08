using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Interfaces;

namespace WindowsFormsApp.Forms.Settings
{
    public partial class ChampionshipGender : UserControl, IReturnable<int>
    {
        public ChampionshipGender()
        {
            InitializeComponent();
        }

        public int Value { 
            get { return rbMale.Checked ? 1 : rbFemale.Checked ? 0 : -1; }
        }

        private void ChampionshipGender_Load(object sender, EventArgs e)
        {
            rbFemale.Text = Program.GetLocalizedString("Female");
            rbMale.Text = Program.GetLocalizedString("Male");
            btnDone.Text = Program.GetLocalizedString("Continue");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (Value == -1) { return; }

            ((IHasMultipleSteps)this.FindForm()).Continue();
        }

        public int ReturnValue() => Value;
    }
}
