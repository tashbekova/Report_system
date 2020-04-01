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
using System.IO;
using System.Data.SqlClient;
using System.Collections;

namespace Report_system
{
    public partial class Form3 : MaterialForm
    {
        public Form3()
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
                    StreamReader SourceFile = File.OpenText(openFileDialog1.FileName);
                    string[] stroka = File.ReadAllLines(openFileDialog1.FileName);
                    string file_name = (Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                    lblName.Text = file_name;
                    if (stroka.Length == 0)
                    {
                        MessageBox.Show("Файл пуст");
                        return;
                    }
                    else if (file_name.Contains('A'))
                    {
                        Check check = new Check();
                        int check_result=check.Check_Report(file_name);
                        if (check_result == 0)
                        {
                            Class_Report_A report_A = new Class_Report_A();
                            report_A.Read_file(openFileDialog1.FileName);
                        }
                        else if(check_result==1)
                        {
                            MessageBox.Show("Этот отчёт уже считан и добавлен в БД");
                        }
                        else if(check_result==2)
                        {
                            MessageBox.Show("Отчёт добавлен с ошибками или не полностью"); 
                        }
                       
                    }
                    else if (file_name.Contains('R'))
                    {
                        MessageBox.Show("Отчёт по пос терминалам");

                    }
                    else if (file_name.Contains('H'))
                    {
                        MessageBox.Show("Отчёт по пос терминалам");
                    }


                }
            }
            catch
            {

            }
            /* try
             {
                 // 1. Открытие окна и проверка, выбран ли файл
                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                     // 2. Вывести имя файла на форме в компоненте label1
                     lblName.Text = openFileDialog1.FileName;
                     // 3. Установить флажки f_open и f_save
                     f_open = true;
                     f_save = false;
                               }
             }
             catch (IOException Exception)
             {
                 Console.Write(Exception);
             }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
