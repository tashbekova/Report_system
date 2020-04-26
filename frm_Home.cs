using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Report_system
{
    public partial class Frm_Home : MaterialForm
    {
        public Frm_Home()
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
            //this.ControlBox = false;
        }
        
        private void CustomizeDesign()
        {
            panelRegularSubMenu.Visible = false;
            panelRequestSubMenu.Visible = false;
            panel_Statisitic_SubMenu.Visible = false;
        }
        private void HideSubMenu()
        {
            if (panelRequestSubMenu.Visible == true)
                panelRequestSubMenu.Visible = false;
            if (panelRequestSubMenu.Visible == true)
                panelRequestSubMenu.Visible = false;
            if (panel_Statisitic_SubMenu.Visible == true)
                panel_Statisitic_SubMenu.Visible = false;
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
            OpenChildForm<frm_Read>();
        }

        private void btn_Generation_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            OpenChildForm<frm_Generation>();
        }

        private void panelRequestSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Show_List_Reports_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            OpenChildForm<frm_List_Report>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Prognoz_Click(object sender, EventArgs e)
        {

        }

        private void button_Statistika_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_Statisitic_SubMenu) ;
        }


        private void button_Make_statistics_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            OpenChildForm<frm_Statistic>();
        }
    }
}
