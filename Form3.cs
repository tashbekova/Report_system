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
                if(openFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    StreamReader SourceFile = File.OpenText(openFileDialog1.FileName);
                    string[] stroka = File.ReadAllLines(openFileDialog1.FileName);
                    if (stroka.Length == 0)
                    {
                        MessageBox.Show("Файл пуст");
                        return;
                    }
                    string file_name =(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                    if (file_name.Contains('A'))
                    {
                        MessageBox.Show("Отчёт по банкоматам");
                        
                        string line = "";
                        string string_financial_value="";
                        string string_office_value = "";
                        string string_contract_value = "";
                        string string_region_value = "";
                        string string_currency_value = "";

                        //provide the table name in which you would like to load data
                        string TableName = "dbo.tbl_repA";

                        //Create Connection to SQL Server
                        SqlConnection SQLConnection = new SqlConnection();
                        SQLConnection.ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";



                        while (!SourceFile.EndOfStream)
                        {
                            line = SourceFile.ReadLine();
                            if (line == "" || line.StartsWith(" --------"))
                            {
                                continue;
                            }
                            else
                            {
                                MessageBox.Show(line);

                                //объявление и инициализация переменных
                                
                                int index_probel = 0;    //индекс пробела равный пяти пробелам
                                int index_probel_3 = 0; //индекс пробела равный трём пробелам
                                int end_line = 0;   //конец строки
                                end_line = line.Length;    //значение конца строки
                                index_probel = line.IndexOf("     ", 0, end_line);   //индекс нахождения пробелов
                                index_probel_3 = line.IndexOf("   ", 0, end_line);   //индекс нахождения пробелов
                                char[] arr_line= { };
                               //переводим строку в массив ,где будет хранится эта строка
                                arr_line = line.ToCharArray();

                                #region Financial Institution
                                int index_financial = 0; //индекс Financial institution
                                //присвоение значений переменным
                                index_financial = line.IndexOf("Institution:", 0, end_line);  //индекс нахождения Financial Institution
                                //Если это строка с Financial Institution
                                if (index_financial >= 0)
                                { 
                                    //создаем лист arr_financial_value для хранения значения Financial iInstitution
                                    List<char> arr_financial_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Financial Institution" и до пробелов
                                    for (int i = index_financial+15; i < index_probel; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        arr_financial_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Financial Institution
                                    string_financial_value = new string(arr_financial_value.ToArray());
                                    MessageBox.Show(string_financial_value);
                                }
                                #endregion

                                #region Office
                               // MessageBox.Show("" + index_probel);
                                int index_office = 0;
                                //присвоение значений переменным
                                index_office = line.IndexOf("Office:", 0, end_line);  //индекс нахождения Office
                              //  MessageBox.Show("" + index_office);
                                //Если это строка с Office
                                if (index_office >= 0)
                                {
                                    //создаем лист arr_office_value для хранения значения Office
                                    List<char> arr_office_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Office:" и до пробелов
                                    for (int i = index_office+11; i < end_line; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        arr_office_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Office
                                    string_office_value = new string(arr_office_value.ToArray());
                                    MessageBox.Show(string_office_value);
                                }
                                #endregion

                                #region Contract
                                // MessageBox.Show("" + index_probel);
                                int index_contract = 0;
                                //присвоение значений переменным
                                index_contract = line.IndexOf("Contract #:", 0, end_line);  //индекс нахождения Contract
                               // MessageBox.Show("" + index_contract);
                                //Если это строка с Contract
                                if (index_contract >= 0)
                                {
                                    //создаем лист arr_contract_value для хранения значения Contract
                                    List<char> arr_contract_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Contract:" и до пробелов
                                    for (int i = index_contract+11; i < end_line; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        arr_contract_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Contract
                                    string_contract_value = new string(arr_contract_value.ToArray());
                                    MessageBox.Show(string_contract_value);
                                }
                                #endregion

                                #region Region
                                // MessageBox.Show("" + index_probel);
                                int index_region = 0;
                                //присвоение значений переменным
                                index_region= line.IndexOf("Reg #:", 0, end_line);  //индекс нахождения Region
                                 // MessageBox.Show("" + index_contract);
                                 //Если это строка с "Reg #:"
                                if (index_region >= 0)
                                {
                                    //создаем лист arr_region_value для хранения значения Region
                                    List<char> arr_region_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Reg #:" и до конца
                                    for (int i = index_region + 11; i < end_line; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        arr_region_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Region
                                    string_region_value = new string(arr_region_value.ToArray());
                                    MessageBox.Show(string_region_value);
                                }
                                #endregion

                                #region Currency
                                 MessageBox.Show("" + index_probel_3);
                                int index_currency = 0;
                                //присвоение значений переменным
                                index_currency = line.IndexOf("Currency:", 0, end_line);  //индекс нахождения Currency
                                // MessageBox.Show("" + index_contract);
                                //Если это строка с "Currency:"
                                if (index_currency >= 0)
                                {
                                    //создаем лист arr_currency_value для хранения значения Currency
                                    List<char> arr_currency_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Currency:" и до пробелов
                                    for (int i = index_currency + 15; i < index_probel_3; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        arr_currency_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Currenct
                                    string_currency_value = new string(arr_currency_value.ToArray());
                                    MessageBox.Show(string_currency_value);
                                }
                                #endregion


                            }


                        }
                        SQLConnection.Open();
                       /*for(int i = 0; i < stroka.Length; i++)
                        {
                            if (stroka[i] == null)
                            {
                                i++;
                                continue;
                            }
                            else
                            {
                                stroka[i] = line;
                                MessageBox.Show(stroka[i]);
                                for(int j=0;j<line.Length;j++)
                                {
                                    int index = 0;
                                    int end = 0;
                                    end = line.Length;
                                    index = line.IndexOf("institution", 0, end);
                                    MessageBox.Show(""+index);
                                }
                                return;
                            }
                        }
                       */

                        
                       


                        //skip the header row
                        /* if (counter > 0)
                         {
                             //prepare insert query
                             string query = "Insert into " + TableName +
                                    " Values ('" + line.Replace(filedelimiter, "','") + "')";

                             //execute sqlcommand to insert record
                             SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                             myCommand.ExecuteNonQuery();
                         }
                         //counter++;
                     }*/

                        SourceFile.Close();
                        SQLConnection.Close();
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
    }
}
