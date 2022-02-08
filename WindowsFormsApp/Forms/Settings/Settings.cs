using DataAccessLayer.Model;
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
    public partial class Settings : Form, IHasMultipleSteps
    {
        public Settings()
        {
            InitializeComponent();
        }

        private IDictionary<int, int> results;
        private bool _keepAlive = false;

        private void Settings_Load(object sender, EventArgs e)
        {
            this.Text = Program.GetLocalizedString("Settings");
            
            var tp = new TabPage();
            tp.Controls.Add(new Language());
            tp.Text = Program.GetLocalizedString("Language");
            tcWizard.TabPages.Add(tp);

            tp = new TabPage();
            tp.Controls.Add(new ChampionshipGender());
            tp.Text = Program.GetLocalizedString("Championship");
            tcWizard.TabPages.Add(tp);
            
            results = new Dictionary<int, int>();
        }

        void IHasMultipleSteps.Continue()
        {
            var page = tcWizard.TabPages[tcWizard.SelectedIndex].Controls.OfType<IReturnable<int>>().First();
            var tempVal = page.ReturnValue(); 
            if(tempVal == -1) { return; }

            results[tcWizard.SelectedIndex] = tempVal;

            if (tcWizard.SelectedIndex == tcWizard.TabCount - 1)
            {
                FinishSetup();
                return;
            }
            tcWizard.SelectedIndex = (tcWizard.SelectedIndex + 1 <= tcWizard.TabCount) ?
                             tcWizard.SelectedIndex + 1 : tcWizard.SelectedIndex;
        }

        private void FinishSetup()
        {
            UserSettings user;
            try
            {
                user = new UserSettings(results[0], results[1]);
                Program.UpdateUser(user);
                try
                {
                    DataAccessLayer.DataHandler.SaveUserSettings(user);
                    _keepAlive = true;
                }
                catch (Exception)
                {
                    CancelSetup();
                }
            }
            catch (Exception)
            {
                _keepAlive = false;
                CancelSetup();
            }
            finally
            {
                this.Close();
            }
        }

        private void CancelSetup()
        {
            MessageBox.Show(Program.GetLocalizedString("errorSetup"));
            try
            {
                DataAccessLayer.DataHandler.WipeUserSettings();
            }
            catch
            {
                MessageBox.Show(Program.GetLocalizedString("errorCancelSetup"), Program.GetLocalizedString("userSettingsError"));
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
