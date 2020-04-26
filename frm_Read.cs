using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Data.SqlClient;

namespace Report_system
{
    public partial class frm_Read : MaterialForm
    {
        public frm_Read()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Amber600, Primary.Teal200, Accent.Teal200, TextShade.WHITE);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
                    swatch.Start();
                    StreamReader SourceFile = File.OpenText(openFileDialog1.FileName);
                    string[] stroka = File.ReadAllLines(openFileDialog1.FileName);
                    string file_name = (Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                    lblName.Text = file_name;
                    if (stroka.Length == 0)
                    {
                        MessageBox.Show("Файл пуст");
                        return;
                    }
                    {
                        Check check = new Check();
                        int check_result=check.Check_Report(file_name);
                        if (check_result == 0)
                        {
                            MessageBox.Show("Отчет не добавлен");
                            Add_Report(file_name);
                            Read_Report_A report_A = new Read_Report_A();
                            report_A.Read_file(openFileDialog1.FileName);
                        }
                        else if(check_result==1)
                        {
                            MessageBox.Show("Этот отчёт уже считан и добавлен в БД");
                        }
                        else if(check_result==2)
                        {
                            MessageBox.Show("Отчёт добавлен с ошибками или не полностью");
                            Read_Report_A report_A = new Read_Report_A();
                            report_A.Read_file(openFileDialog1.FileName);
                        }
                       
                    }
                    // Тут ваш код, время выполнения которого нужно измерить
                    swatch.Stop();
                    MessageBox.Show("" + swatch.Elapsed);

                }
            }
            catch
            {

            }
           
        }
        private void Add_Report(string File_name)
        {
            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string Table_Name = "";
            if (File_name.Contains('A'))
            {
                Table_Name = "dbo.tbl_Result_Report_A";
            }
            else if (File_name.Contains('H'))
            {
                Table_Name = "dbo.tbl_Result_Report_H";
            }
            else if (File_name.Contains('R'))
            {
                Table_Name = "dbo.tbl_Result_Report_R";
            }
            // запрос на добавление в SQL Server
            string query = "Insert into " + Table_Name +
                " (Name_of_report,Finish) "+
           " Values ('" + File_name + "','0')";
            try
            {
                SQLConnection.Open();
                //execute sqlcommand to insert record
                SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении названия отчёта в БД" + ex);
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
