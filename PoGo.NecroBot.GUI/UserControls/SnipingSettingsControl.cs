using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using PoGo.NecroBot.Logic;

namespace PoGo.NecroBot.GUI.UserControls
{
    public partial class SnipingSettingsControl : UserControl
    {
        public SnipingSettingsControl()
        {
            InitializeComponent();
        }

        public void SetSetting(string setting, string value)
        {
            Control[] control = Controls.Find(setting, true);
            if (control != null && control.Length > 0)
            {
                if (control[0] is TextBox)
                {
                    control[0].Text = value;
                }
                if (control[0] is CheckBox)
                {
                    ((CheckBox)control[0]).Checked = Convert.ToBoolean(value);
                }

            }
        }

        public string GetSetting(string setting)
        {
            string value = "";

            Control[] control = Controls.Find(setting, true);
            if (control != null && control.Length > 0)
            {
                if (control[0] is TextBox)
                {
                    value = control[0].Text;
                }
                if (control[0] is CheckBox)
                {
                    value = Convert.ToString(((CheckBox)control[0]).Checked);
                }

            }

            return value;
        }

        public void SetLocations(List<Location> locations)
        {
            foreach(var location in locations)
            {
                dataLocations.Rows.Add(location.Latitude, location.Longitude);
            }
        }

        public List<Location> GetLocations()
        {
            List<Location> locationsList = new List<Location>();

            foreach (DataGridViewRow row in dataLocations.Rows)
            {
                try
                {
                    double lat = Convert.ToDouble(row.Cells[0].Value.ToString());
                    double lng = Convert.ToDouble(row.Cells[1].Value.ToString());

                    locationsList.Add(new Location(lat, lng));
                }
                catch { }
            }

            return locationsList;
        }
    }
}
