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

namespace PoGo.NecroBot.GUI
{
    public partial class GUILogin : Form
    {
        public string ProfileFolder { get; set; }
        public string ProfileName { get; set; }

        private Dictionary<string, string> _profilesList = new Dictionary<string, string>();
        private bool _close = false;

        public GUILogin()
        {
            InitializeComponent();
        }

        private void GUILogin_Load(object sender, EventArgs e)
        {
            UpdateCombo();
        }

        private void UpdateCombo()
        {
            cboProfiles.Items.Clear();
            _profilesList.Clear();
            string profilesFolder = Directory.GetCurrentDirectory() + "\\config\\profiles\\";

            if (Directory.Exists(profilesFolder))
            {
                DirectoryInfo directory = new DirectoryInfo(profilesFolder);
                DirectoryInfo[] directories = directory.GetDirectories();
                foreach (DirectoryInfo profile in directories)
                {
                    _profilesList.Add(profile.Name, profile.FullName);
                    cboProfiles.Items.Add(profile.Name);
                }
            }
            else
            {
                Directory.CreateDirectory(profilesFolder);
                MessageBox.Show("Move your profiles in seperate folder under " + profilesFolder);
                Environment.Exit(0);
            }
        }

        private void cmdLoadProfile_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(cboProfiles.Text))
            {
                MessageBox.Show("Pick a profile");
            }
            else
            {
                _close = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProfileFolder = _profilesList[cboProfiles.Text];
            this.ProfileName = cboProfiles.Text;
        }

        private void GUILogin_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (_close == false)
                Environment.Exit(0);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string profilesFolder = Directory.GetCurrentDirectory() + "\\config\\profiles\\" + textUsername.Text + "\\auth.json";
            var newProfile = new AuthSettings();
            newProfile.NewProfile(textUsername.Text, textPassword.Text, radioGoogle.Checked ? PokemonGo.RocketAPI.Enums.AuthType.Google : PokemonGo.RocketAPI.Enums.AuthType.Ptc, profilesFolder);
            textUsername.Text = "";
            textPassword.Text = "";
            radioGoogle.Checked = true;
            UpdateCombo();
        }
    }
}
