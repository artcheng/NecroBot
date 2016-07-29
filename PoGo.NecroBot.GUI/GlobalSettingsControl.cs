using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoGo.NecroBot.GUI
{
    public partial class GlobalSettingsControl : UserControl
    {
        public GlobalSettingsControl()
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
                if(control[0] is CheckBox)
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
    }
}
