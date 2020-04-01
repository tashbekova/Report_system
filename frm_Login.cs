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
using System.Data.SqlClient;

namespace Report_system
{
    public partial class frm_Login : MaterialForm
    {
        public frm_Login()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal500, Primary.Amber600, Primary.Teal100, Accent.Teal100, TextShade.WHITE);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'");
            string query = "Select * from tbl_User Where Login = '" + txtLogin.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count==1)
            {
                Frm_Home newform = new Frm_Home();
                this.Hide();
                newform.Show();
            }
            else
            {
                MessageBox.Show("Проверьте логин или пароль");

            }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Frm_Home newform = new Frm_Home();
            this.Hide();
            newform.Show();
            frm_Login form = new frm_Login();
            form.Close();
            //this.Close();
        }
    }
}
