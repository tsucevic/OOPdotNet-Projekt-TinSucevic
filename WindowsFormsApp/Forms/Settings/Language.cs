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
    public partial class Language : UserControl, IReturnable<int>
    {
        public Language()
        {
            InitializeComponent();
        }

        private void Language_Load(object sender, EventArgs e)
        {
            btnDone.Text = Program.GetLocalizedString("Continue");
        }

        public int Value
        {
            get { return rbCroatian.Checked ? 1 : rbEnglish.Checked ? 0 : -1; }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (Value == -1) { return; }

            ((IHasMultipleSteps)this.FindForm()).Continue();
        }

        public int ReturnValue() => Value;
    }
}
