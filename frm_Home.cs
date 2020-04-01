using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Report_system
{
    public partial class frm_Home : MaterialForm
    {
        public frm_Home()
        {
            InitializeComponent();
           
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal500, Primary.Amber600, Primary.Teal100, Accent.Teal100, TextShade.WHITE); 
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;
            CustomizeDesign();
        }

 

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void CustomizeDesign()
        {
            panelRegularSubMenu.Visible = false;
            panelRequestSubMenu.Visible = false;
        }
        private void HideSubMenu()
        {
            if (panelRequestSubMenu.Visible == true)
                panelRequestSubMenu.Visible = false;
            if (panelRequestSubMenu.Visible == true)
                panelRequestSubMenu.Visible = false;
        }
       private void ShowSubMenu(Panel subMenu)
        {
            if(subMenu.Visible==false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #region Regular report
        private void btnRegular_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(panelRegularSubMenu);
        }

        #endregion

        #region Request report
        private void btnRequest_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelRequestSubMenu);
        }
        #endregion


        private void OpenChildForm<MiForm>()where MiForm:Form, new() 
        {
            Form child;
            child = panelChildForm.Controls.OfType<MiForm>().FirstOrDefault();
            if(child==null)
            {
                child = new MiForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelChildForm.Controls.Add(child);
                panelChildForm.Tag = child;
                child.Show();
                child.BringToFront();
            }
            else
            {
                child.BringToFront();
            }
        }
       

        private void panelSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMakeRegularReport_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            OpenChildForm<Read>();
        }
    }
}
