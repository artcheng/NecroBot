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
using PoGo.NecroBot.CLI;
using static PoGo.NecroBot.GUI.GUISettings;

namespace PoGo.NecroBot.GUI
{
    public partial class GUILogin : Form
    {
        public string _loginProfileFolder { get; set; }
        public string _loginProfileName { get; set; }
        public bool _loginUseGPX { get; set; }
        public string _loginGPXFile { get; set; }
        public bool _loginUseLastCoords { get; set; }
        public double _loginLastLat { get; set; }
        public double _loginLastLng { get; set; }
        public ProfileSettings _profileSettings { get; set; }

        private Dictionary<string, string> _profilesList = new Dictionary<string, string>();
        private bool _close = false;

        public Dictionary<string,ProfileSettings> guiSettingsList = new Dictionary<string, ProfileSettings>();

        public GUILogin()
        {
            InitializeComponent();
        }

        private void GUILogin_Load(object sender, EventArgs e)
        {
            UpdateProfilesCombo();
            UpdateGPXCombo();
        }

        private void UpdateProfilesCombo()
        {
            string lastProfileLoaded = "";
            comboProfiles.Items.Clear();
            comboCopyConfig.Items.Clear();
            _profilesList.Clear();
            comboCopyConfig.Items.Add("");
            string profilesFolder = Directory.GetCurrentDirectory() + "\\config\\profiles\\";

            if (Directory.Exists(profilesFolder))
            {
                DirectoryInfo directory = new DirectoryInfo(profilesFolder);
                DirectoryInfo[] directories = directory.GetDirectories();
                foreach (DirectoryInfo profile in directories)
                {
                    if (File.Exists(profilesFolder + profile.Name + "\\auth.json") && File.Exists(profilesFolder + profile.Name + "\\config.json"))
                    {
                        if (!Directory.Exists(profilesFolder + profile.Name + "\\config"))
                            Directory.CreateDirectory(profilesFolder + profile.Name + "\\config");

                        File.Move(profilesFolder + profile.Name + "\\auth.json", profilesFolder + profile.Name + "\\config\\auth.json");
                        File.Move(profilesFolder + profile.Name + "\\config.json", profilesFolder + profile.Name + "\\config\\config.json");
                    }

                    _profilesList.Add(profile.Name, profile.FullName);
                    comboProfiles.Items.Add(profile.Name);
                    comboCopyConfig.Items.Add(profile.Name);

                    if (guiSettingsList.ContainsKey(profile.Name))
                    {
                        guiSettingsList[profile.Name] = ProfileSettings.Load(profilesFolder + profile.Name + "\\");
                    }
                    else
                    {
                        guiSettingsList.Add(profile.Name, ProfileSettings.Load(profilesFolder + profile.Name + "\\"));
                    }

                    if (guiSettingsList[profile.Name].IsLastProfile)
                        lastProfileLoaded = profile.Name;
                }

                comboProfiles.Text = lastProfileLoaded;
            }
            else
            {
                Directory.CreateDirectory(profilesFolder);
            }
        }

        private void UpdateGPXCombo()
        {
            comboGPXFiles.Items.Clear();
            string gpxFolder = Directory.GetCurrentDirectory() + "\\config\\GPX\\";

            if (Directory.Exists(gpxFolder))
            {
                string[] files = Directory.GetFiles(gpxFolder);

                foreach (string file in files)
                {
                    
                    comboGPXFiles.Items.Add(Path.GetFileName(file));
                }
            }
            else
            {
                Directory.CreateDirectory(gpxFolder);
            }
        }

        private void cmdLoadProfile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboProfiles.Text))
            {
                MessageBox.Show("Pick a profile");
            }
            else
            {
                _loginProfileFolder = _profilesList[comboProfiles.Text];
                _loginProfileName = comboProfiles.Text;

                _loginUseGPX = checkGPX.Checked;
                _loginGPXFile = Directory.GetCurrentDirectory() + "\\config\\GPX\\" + comboGPXFiles.Text;

                _loginUseLastCoords = checkUseLastCoords.Checked;
                _loginLastLat = guiSettingsList[comboProfiles.Text].LastLat;
                _loginLastLng = guiSettingsList[comboProfiles.Text].LastLng;

                guiSettingsList[comboProfiles.Text].IsLastProfile = true;
                guiSettingsList[comboProfiles.Text].UseLiveMap = checkLiveMap.Checked;
                guiSettingsList[comboProfiles.Text].Save();

                _profileSettings = guiSettingsList[comboProfiles.Text];

                _close = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void GUILogin_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (_close == false)
                Environment.Exit(0);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string profilesFolder = Directory.GetCurrentDirectory() + "\\config\\profiles\\" + textUsername.Text + "\\config\\auth.json";
            var newProfile = new AuthSettings();
            newProfile.NewProfile(textUsername.Text, textPassword.Text, radioGoogle.Checked ? PokemonGo.RocketAPI.Enums.AuthType.Google : PokemonGo.RocketAPI.Enums.AuthType.Ptc, profilesFolder);

            if(String.IsNullOrEmpty(comboCopyConfig.Text))
            {
                GlobalSettings settings = new GlobalSettings();
                settings.Save(Directory.GetCurrentDirectory() + "\\config\\profiles\\" + textUsername.Text + "\\config\\config.json");
            }
            else
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\config\\profiles\\" + comboCopyConfig.Text + "\\config\\config.json"))
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\config\\profiles\\" + textUsername.Text + "\\config"))
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\config\\profiles\\" + textUsername.Text + "\\config");

                    File.Copy(Directory.GetCurrentDirectory() + "\\config\\profiles\\" + comboCopyConfig.Text + "\\config\\config.json", Directory.GetCurrentDirectory() + "\\config\\profiles\\" + textUsername.Text + "\\config\\config.json");
                }
            }

            UpdateProfilesCombo();
            tabProfiles.SelectedIndex = 0;
            comboProfiles.Text = textUsername.Text;
            textUsername.Text = "";
            textPassword.Text = "";
            radioGoogle.Checked = true;
        }

        private void checkGPX_CheckedChanged(object sender, EventArgs e)
        {
            comboGPXFiles.Enabled = checkGPX.Checked;
            checkUseLastCoords.Checked = !checkGPX.Checked;
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkUseLastCoords.Checked = guiSettingsList[comboProfiles.Text].UseLiveMap;
            checkUseLastCoords.Text = "Use last coords: " + guiSettingsList[comboProfiles.Text].LastLat.ToString() + "," + guiSettingsList[comboProfiles.Text].LastLng.ToString();
        }

        private void checkUseLastCoords_CheckedChanged(object sender, EventArgs e)
        {
            checkGPX.Checked = !checkUseLastCoords.Checked;
        }
    }
}
