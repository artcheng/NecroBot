using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoGo.NecroBot.GUI
{
    public partial class MDI : Form
    {
        private static MDI _parent;
        private static int childFormNumber = 0;
        public static Dictionary<string, GUI> _botList = new Dictionary<string, GUI>();

        public MDI()
        {
            InitializeComponent();
            _parent = this;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            GUI newBot = new GUI();
            //newBot.FormClosed += StopBot;
            newBot.MdiParent = this;
            //newBot.Tag = "New bot " + childFormNumber++;
            _botList.Add("NecroBot " + childFormNumber++, newBot);

            //Application.EnableVisualStyles();
            //Application.Run(newBot);
            newBot.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

         private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (GUI childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            // If no any child form, hide tabControl 
            else
            {
                //this.ActiveMdiChild.WindowState =
                //FormWindowState.Maximized;
                // Child form always maximized 

                // If child form is new and no has tabPage, 
                // create new tabPage 
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage("NecroBot " + childFormNumber);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                        new FormClosedEventHandler(
                                        ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;

            }
        }
        private void ActiveMdiChild_FormClosed(object sender,
                                    FormClosedEventArgs e)
        {
            ((sender as GUI).Tag as TabPage).Dispose();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabForms.SelectedTab != null) &&
                (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as GUI).Select();
        }
    }
}
