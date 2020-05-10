using System;
using System.Data;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Data.OleDb;

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
            Connection sql = new Connection();
            string ConnectionString = sql.Get_Connection_String();
            SqlConnection sqlcon = new SqlConnection(ConnectionString);
            string query = "Select * from tbl_User Where Login = '" + txtLogin.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count==1)
            {
                frm_Login form = new frm_Login();
                form.Close();
                //form.Hide();
                Frm_Home newform = new Frm_Home();
                newform.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте логин или пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            frm_Login form = new frm_Login();
            form.Close();
            //form.Hide();
            Frm_Home newform = new Frm_Home();
            newform.Show();
            //this.Close();
            /////
            //DataTable table = new OleDbEnumerator().GetElements();
            //string inf = "";
            //foreach (DataRow row in table.Rows)
            //    inf += row["SOURCES_NAME"] + "\n";

            //MessageBox.Show(inf);
        }
    }
}
