using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

        private async void button_Read_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            try
            {
                //Виден прогресс бар
                pb_Status.Visible = true;
                //Кнопка считывания блокируется до окончания считывания
                button_Read.Enabled = false;
                //Если файл выбран
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader SourceFile = File.OpenText(openFileDialog1.FileName);
                    string[] stroka = File.ReadAllLines(openFileDialog1.FileName);
                    //Название файла
                    string file_name = (Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                    //Показываем на форме названия считываемого файла
                    lblName.Text = file_name;
                    //Если файл пустой
                    if (stroka.Length == 0)
                    {
                        MessageBox.Show("Файл пуст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //Проверяем не добавлен ли этой отчет уже в БД
                        Check check = new Check();
                        int check_result=check.Check_Report(file_name);
                        //Если отчет еще не добавлен,то добавляем в БД
                        if (check_result == 0)
                        {
                            //Добавляем в таблицу название считываемого файла
                            Add_Report(file_name);
                            //Распознаем и считываем данные файла
                            Read_Report_A report_A = new Read_Report_A();
                            await Task.Run(() => report_A.Read_file(openFileDialog1.FileName));
                            MessageBox.Show("Добавлено");
                        }
                        else if(check_result==1)
                        {
                            MessageBox.Show("Этот отчёт уже считан и добавлен в БД");
                        }
                        else if(check_result==2)
                        {
                            //MessageBox.Show("Отчёт добавлен с ошибками или не полностью");
                            Read_Report_A report_A = new Read_Report_A();
                            await Task.Run(() => report_A.Read_file(openFileDialog1.FileName));
                            MessageBox.Show("Добавлено");
                        }
                       
                    }
                }
            }
            catch(Exception ex)
            {
                pb_Status.Visible = false;
                button_Read.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Разблокируем кнопку считывания
                button_Read.Enabled = true;
                //Убираем прогресс бар
                pb_Status.Visible = false;
                lblName.Text = "";
                GC.Collect();
            }
           
        }
        private void Add_Report(string File_name)
        {
            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string Table_Name = "";
            //Определяем по названию файла в какую таблицу добавлять данные
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
                MessageBox.Show("Произошла ошибка при добавлении названия отчёта в БД " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLConnection.Close();
                GC.Collect();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button_Read_Directory_Click(object sender, EventArgs e)
        {
            try
            {
                //Виден прогресс бар
                pb_Status.Visible = true;
                //Кнопка считывания блокируется до окончания считывания
                button_Read.Enabled = false;
                //Если папка выбрана
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    string path_directory = FBD.SelectedPath;
                    string[] fileEntries = Directory.GetFiles(path_directory);
                    foreach (string fileName in fileEntries)
                    {
                        string[] stroka = File.ReadAllLines(fileName);
                        //Название файла
                        string short_file_name = (Path.GetFileNameWithoutExtension(fileName));
                        //Показываем на форме названия считываемого файла
                        lblName.Text = short_file_name;
                        //Если файл пустой
                        if (stroka.Length == 0)
                        {
                            MessageBox.Show(short_file_name+ " пуст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            //Проверяем не добавлен ли этой отчет уже в БД
                            Check check = new Check();
                            int check_result = check.Check_Report(short_file_name);
                            //Если отчет еще не добавлен,то добавляем в БД
                            if (check_result == 0)
                            {
                                //Добавляем в таблицу название считываемого файла
                                Add_Report(short_file_name);
                                //Распознаем и считываем данные файла
                                Read_Report_A report = new Read_Report_A();
                                await Task.Run(() => report.Read_file(fileName));
                            }
                            else if (check_result == 1)
                            {
                                MessageBox.Show(short_file_name+ " отчёт уже считан и добавлен в БД");
                                continue;
                            }
                            else if (check_result == 2)
                            {
                                Read_Report_A report = new Read_Report_A();
                                await Task.Run(() => report.Read_file(fileName));
                            }

                        }
                    }
                }
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                pb_Status.Visible = false;
                button_Read.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Разблокируем кнопку считывания
                button_Read.Enabled = true;
                //Убираем прогресс бар
                pb_Status.Visible = false;
                lblName.Text = "";
                GC.Collect();
            }
        }
    }
}
