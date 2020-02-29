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
                    if (stroka.Length == 0)
                    {
                        MessageBox.Show("Файл пуст");
                        return;
                    }
                    string file_name = (Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                    if (file_name.Contains('A'))
                    {
                        MessageBox.Show("Отчёт по банкоматам");

                        int index_Transaction_Name = 0; //индекс Transaction Name
                        int index_Trans_Date = 49;

                        int count_column = 0;
                        int count_line = 0;
                        int flag_Transaction = 0;
                        int count = 0;
                        bool flag = false;
                        string line = "";
                        string string_Financial_value = "";
                        string string_Office_value = "";
                        string string_Contract_value = "";
                        string string_Region_value = "";
                        string string_Currency_value = "";
                        string string_Date_value = "";
                        string string_Device_value = "";
                        string string_SIC_value = "";
                        string string_Cycle_value = "";
                        string string_Device_Name_value = "";

                        string string_Transaction_Name_value = "";

                        string string_Trans_value = "";
                        string string_Transaction_Amount_value = "";
                        string string_Discount_value = "";
                        string string_Account_Amount_value = "";

                        string string_Transaction_Name_value_part_1 = "";
                        string string_Transaction_Name_value_part_2 = "";


                        //provide the table name in which you would like to load data
                        string TableName = "dbo.Table_A";

                        //Create Connection to SQL Server
                        SqlConnection SQLConnection = new SqlConnection();
                        SQLConnection.ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";


                        SQLConnection.Open();

                        while (!SourceFile.EndOfStream)
                        {
                            line = SourceFile.ReadLine();
                            if (line.StartsWith(" --------"))
                            {
                                continue;
                            }
                            else
                            {
                                //MessageBox.Show(line);

                                //объявление и инициализация переменных

                                int index_probel = 0;    //индекс пробела равный пяти пробелам
                                int end_line = 0;   //конец строки
                                end_line = line.Length;    //значение конца строки

                                index_probel = line.IndexOf("     ", 0, end_line);   //индекс нахождения пробелов
                                char[] arr_line = { };
                                //переводим строку в массив ,где будет хранится эта строка
                                arr_line = line.ToCharArray();


                                // -------------------------------------------------------------------

                               // -------------------------------------------------------------------


                                #region Financial Institution
                                int index_Financial = 0; //индекс Financial institution
                                //присвоение значений переменным
                                index_Financial = line.IndexOf("Institution:", 0, end_line);  //индекс нахождения Financial Institution
                                //Если это строка с Financial Institution
                                if (index_Financial >= 0)
                                {
                                    //создаем лист list_financial_value для хранения значения Financial iInstitution
                                    List<char> list_Financial_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Financial Institution" и до пробелов
                                    for (int i = index_Financial + 15; i < index_probel; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        list_Financial_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Financial Institution
                                    string_Financial_value = new string(list_Financial_value.ToArray());
                                    MessageBox.Show(string_Financial_value);
                                    list_Financial_value.Clear();
                                }
                                #endregion
                                
                                #region Date
                                int index_Date = 0; //индекс Date
                                //присвоение значений переменным
                                index_Date = line.IndexOf("Period  to", 0, end_line);  //индекс нахождения Period
                                //Если это строка с Period
                                if (index_Date >= 0)
                                {
                                    //создаем лист list_Date_value для хранения значения Date
                                    List<char> list_Date_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Period to" и до пробелов
                                    for (int i = index_Date + 11; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Date_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Date_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Date
                                    string_Date_value = new string(list_Date_value.ToArray());
                                    list_Date_value.Clear();
                                    MessageBox.Show(string_Date_value);
                                }
                                #endregion



                               #region Office

                                #region Date
                                int index_Date = 0; //индекс Date
                                //присвоение значений переменным
                                index_Date = line.IndexOf("Period  to", 0, end_line);  //индекс нахождения Period
                                //Если это строка с Period
                                if (index_Date >= 0)
                                {
                                    //создаем лист list_Date_value для хранения значения Date
                                    List<char> list_Date_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Period to" и до пробелов
                                    for (int i = index_Date + 11; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Date_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Date_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Date
                                    string_Date_value = new string(list_Date_value.ToArray());
                                    MessageBox.Show(string_Date_value);
                                }
                                #endregion

                                #region Office

                                // MessageBox.Show("" + index_probel);
                                int index_Office = 0;
                                //присвоение значений переменным
                                index_Office = line.IndexOf("Office:", 0, end_line);  //индекс нахождения Office
                                                                                      //  MessageBox.Show("" + index_office);
                                                                                      //Если это строка с Office
                                if (index_Office >= 0)
                                {
                                    //создаем лист list_office_value для хранения значения Office
                                    List<char> list_Office_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Office:" и до пробелов
                                    for (int i = index_Office + 11; i < end_line; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        list_Office_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Office
                                    string_Office_value = new string(list_Office_value.ToArray());

                                    list_Office_value.Clear();

                                    MessageBox.Show(string_Office_value);
                                }
                                #endregion


                                #region Contract
                                // MessageBox.Show("" + index_probel);
                                int index_Contract = 0;
                                //присвоение значений переменным
                                index_Contract = line.IndexOf("Contract #:", 0, end_line);  //индекс нахождения Contract
                                                                                            // MessageBox.Show("" + index_contract);
                                                                                            //Если это строка с Contract
                                if (index_Contract >= 0)
                                {
                                    //создаем лист list_Contract_value для хранения значения Contract
                                    List<char> list_Contract_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Contract:" и до пробелов
                                    for (int i = index_Contract + 11; i < end_line; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        list_Contract_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Contract
                                    string_Contract_value = new string(list_Contract_value.ToArray());

                                    list_Contract_value.Clear();

                                    MessageBox.Show(string_Contract_value);
                                }
                                #endregion


                                #region Region
                                // MessageBox.Show("" + index_probel);
                                int index_Region = 0;
                                //присвоение значений переменным
                                index_Region = line.IndexOf("Reg #:", 0, end_line);  //индекс нахождения Region
                                                                                     // MessageBox.Show("" + index_contract);
                                                                                     //Если это строка с "Reg #:"
                                if (index_Region >= 0)
                                {
                                    //создаем лист list_Region_value для хранения значения Region
                                    List<char> list_Region_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Reg #:" и до конца
                                    for (int i = index_Region + 11; i < end_line; i++)
                                    {
                                        //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                        list_Region_value.Add(arr_line[i]);
                                    }
                                    //преобразовали в строку,где хранится значение Region
                                    string_Region_value = new string(list_Region_value.ToArray());

                                    list_Region_value.Clear();

                                    MessageBox.Show(string_Region_value);
                                }
                                #endregion


                                #region Currency
                                // MessageBox.Show("" + index_probel_3);
                                int index_Currency = 0;
                                //присвоение значений переменным
                                index_Currency = line.IndexOf("Currency:", 0, end_line);  //индекс нахождения Currency
                                // MessageBox.Show("" + index_contract);
                                //Если это строка с "Currency:"
                                if (index_Currency >= 0)
                                {
                                    //создаем лист arr_Currency_value для хранения значения Currency
                                    List<char> list_Currency_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Currency:" и до пробелов
                                    for (int i = index_Currency + 15; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Currency_value.Add(arr_line[i]);
                                        }
                                        else
                                        {//добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Currency_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Currenct
                                    string_Currency_value = new string(list_Currency_value.ToArray());

                                    list_Currency_value.Clear();

                                    MessageBox.Show(string_Currency_value);
                                }
                                #endregion


                                #region Device
                                int index_Device = 0; //индекс Device
                                //присвоение значений переменным
                                index_Device = line.IndexOf("Device:", 0, end_line);  //индекс нахождения Device
                                //Если это строка с Device:
                                if (index_Device >= 0)
                                {
                                    //создаем лист list_Device_value для хранения значения Device:
                                    List<char> list_Device_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Device:" и до пробелов
                                    for (int i = index_Device + 8; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Device_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Device_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Device
                                    string_Device_value = new string(list_Device_value.ToArray());

                                    list_Device_value.Clear();

                                    MessageBox.Show(string_Device_value);
                                }
                                #endregion


                                #region SIC
                                int index_SIC = 0; //индекс SIC
                                //присвоение значений переменным
                                index_SIC = line.IndexOf("SIC:", 0, end_line);  //индекс нахождения SIC
                                //Если это строка с SIC:
                                if (index_SIC >= 0)
                                {
                                    //создаем лист list_SIC_value для хранения значения SIC:
                                    List<char> list_SIC_value = new List<char>();
                                    //Проходим по циклу начиная после слов "SIC:" и до пробелов
                                    for (int i = index_SIC + 6; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_SIC_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_SIC_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Device
                                    string_SIC_value = new string(list_SIC_value.ToArray());

                                    list_SIC_value.Clear();

                                    MessageBox.Show(string_SIC_value);
                                }
                                #endregion


                                #region Cycle Num/Type
                                int index_Cycle = 0; //индекс Cycle Num/Type:
                                //присвоение значений переменным
                                index_Cycle = line.IndexOf("Cycle Num/Type:", 0, end_line);  //индекс нахождения Cycle Num/Type:
                                //Если это строка с Cycle Num/Type:
                                if (index_Cycle >= 0)
                                {
                                    //создаем лист list_Cycle_value для хранения значения Cycle Num/Type:
                                    List<char> list_Cycle_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Cycle Num/Type:" и до пробелов
                                    for (int i = index_Cycle + 15; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Cycle_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Cycle_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Cycle Num/Type:
                                    string_Cycle_value = new string(list_Cycle_value.ToArray());

                                    list_Cycle_value.Clear();

                                    MessageBox.Show(string_Cycle_value);
                                }
                                #endregion


                                #region Device Name:
                                int index_Device_Name = 0; //индекс Device Name:
                                //присвоение значений переменным
                                index_Device_Name = line.IndexOf("Device Name:", 0, end_line);  //индекс нахождения Device Name:
                                //Если это строка с Device Name:
                                if (index_Device_Name >= 0)
                                {
                                    //создаем лист list_Device_Name_value для хранения значения Device Name:
                                    List<char> list_Device_Name_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Device Name:" и до пробелов
                                    for (int i = index_Device_Name + 15; i < end_line; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Device_Name_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Device_Name_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Device Name:
                                    string_Device_Name_value = new string(list_Device_Name_value.ToArray());

                                    list_Device_Name_value.Clear();
                                    MessageBox.Show(string_Device_Name_value);
                                }
                                #endregion

                                    MessageBox.Show(string_Device_Name_value);
                                }
                                #endregion

                                #region Transaction Name:
     
                                //присвоение значений переменным
                                index_Transaction_Name = line.IndexOf("Transaction Name", 0, end_line);  //индекс нахождения Transaction Name
                                if (index_Transaction_Name>=0)
                                {
                                    flag = true;
                                    continue;
                                }
                                if (flag == true)
                                {
                                    // MessageBox.Show(line);
                                    //MessageBox.Show("" + index_Transaction_Name);
                                    //создаем лист list_Transaction_Name_value для хранения значения Transaction Name:
                                    List<char> list_Transaction_Name_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Transaction Name:" и до пробелов
                                    for (int i = 0 ; i < 37; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Transaction_Name_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Transaction_Name_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Device Name:
                                    string_Device_Name_value = new string(list_Transaction_Name_value.ToArray());
                                    MessageBox.Show(string_Device_Name_value);

                                    
                                    List<char> list_Trans_value = new List<char>();
                                    List<char> list_Transaction_Amount_value = new List<char>();
                                    List<char> list_Discount_value = new List<char>();
                                    List<char> list_Account_Amount_value = new List<char>();
                                    for (int j=index_Trans_Date;j<=end_line;j++)
                                    {
                                        if(arr_line[j]==' ')
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (count == 0)
                                            {
                                                list_Trans_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    count++;
                                                }
                                            }
                                            else if (count == 1)
                                            {
                                                list_Transaction_Amount_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    count++;
                                                }
                                            }
                                            else if (count == 2)
                                            {
                                                list_Discount_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    count++;
                                                }
                                            }
                                            else if (count == 3)
                                            {
                                                list_Account_Amount_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    break;
                                                }
                                            }
                                          
                                        }
                                    }
                                    string_Trans_value = new string(list_Trans_value.ToArray());
                                    string_Transaction_Amount_value = new string(list_Transaction_Amount_value.ToArray());
                                    string_Discount_value = new string(list_Discount_value.ToArray());
                                    string_Account_Amount_value = new string(list_Account_Amount_value.ToArray());
                                    MessageBox.Show(string_Trans_value);
                                    MessageBox.Show(string_Transaction_Amount_value);
                                    MessageBox.Show(string_Discount_value);
                                    MessageBox.Show(string_Account_Amount_value);


                                    flag = false;
                                }
                                #endregion
                            }



                                #region Transaction Name:

                                //присвоение значений переменным
                                index_Transaction_Name = line.IndexOf("Transaction Name", 0, end_line);  //индекс нахождения Transaction Name

                                if (index_Transaction_Name >= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                if (flag == true && count_line==0)
                                {
                                    //создаем лист list_Transaction_Name_value для хранения значения Transaction Name:
                                    List<char> list_Transaction_Name_value = new List<char>();
                                    //Проходим по циклу начиная после слов "Transaction Name:" и до пробелов
                                    for (int i = 0; i < 37; i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i + 1] == ' ')
                                                break;
                                            else
                                                list_Transaction_Name_value.Add(arr_line[i]);
                                        }
                                        else
                                        {
                                            //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                            list_Transaction_Name_value.Add(arr_line[i]);
                                        }
                                    }
                                    //преобразовали в строку,где хранится значение Device Name:
                                    string_Transaction_Name_value_part_1 = new string(list_Transaction_Name_value.ToArray());
                                    //MessageBox.Show(string_Transaction_Name_value_part_1);

                                    List<char> list_Trans_value = new List<char>();
                                    List<char> list_Transaction_Amount_value = new List<char>();
                                    List<char> list_Discount_value = new List<char>();
                                    List<char> list_Account_Amount_value = new List<char>();
                                    for (int j = index_Trans_Date; j <= (end_line-1); j++)
                                    {
                                        
                                        if (arr_line[j] == ' ')
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (count_column == 0)
                                            {
                                                list_Trans_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    string_Trans_value = new string(list_Trans_value.ToArray());
                                                    count_column++;
                                                }
                                            }
                                            else if (count_column == 1)
                                            {
                                                list_Transaction_Amount_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    string_Transaction_Amount_value = new string(list_Transaction_Amount_value.ToArray());
                                                    count_column++;
                                                }
                                            }
                                            else if (count_column == 2)
                                            {
                                                list_Discount_value.Add(arr_line[j]);
                                                if (arr_line[j + 1] == ' ')
                                                {
                                                    string_Discount_value = new string(list_Discount_value.ToArray());
                                                    count_column++;
                                                }
                                            }
                                            else if (count_column == 3)
                                            {
                                                list_Account_Amount_value.Add(arr_line[j]);
                                            }

                                        }

                                    }
                                    count_column = 0;
                                    count_line = 1;
                                    string_Account_Amount_value = new string(list_Account_Amount_value.ToArray());
                                    MessageBox.Show(string_Trans_value);
                                    MessageBox.Show(string_Transaction_Amount_value);
                                    MessageBox.Show(string_Discount_value);
                                    MessageBox.Show(string_Account_Amount_value);
                                }

                                else if(flag==true && count_line==1)
                                {
                                    //создаем лист list_Transaction_Name_value для хранения значения Transaction Name:
                                    List<char> list_Transaction_Name_value_2 = new List<char>();
                                    for (int i=0;i<end_line;i++)
                                    {
                                        if (arr_line[i] == ' ')
                                        {
                                            if (arr_line[i+1] == ' ')
                                                break;
                                            else
                                                list_Transaction_Name_value_2.Add(arr_line[i]);
                                        }
                                        else
                                            list_Transaction_Name_value_2.Add(arr_line[i]);
                                    }
                                    string_Transaction_Name_value_part_2 = new string(list_Transaction_Name_value_2.ToArray());
                                    //MessageBox.Show(string_Transaction_Name_value_part_2);
                                    string_Transaction_Name_value = string_Transaction_Name_value_part_1 + string_Transaction_Name_value_part_2;
                                    MessageBox.Show(string_Transaction_Name_value);
                                    count_line = 0;
                                    list_Transaction_Name_value_2.Clear();
                                    flag = false;
                                    flag_Transaction = 1;
                                   /* string query = "Insert into " + TableName +
                                   " Values ('" +  + "')";

                                    //execute sqlcommand to insert record
                                    SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                                    myCommand.ExecuteNonQuery();*/
                                }
                                if(flag_Transaction==1 && !line.StartsWith("          "))
                                {
                                    if(count_line==0)
                                    {
                                        //создаем лист list_Transaction_Name_value для хранения значения Transaction Name:
                                        List<char> list_Transaction_Name_value = new List<char>();
                                        //Проходим по циклу начиная после слов "Transaction Name:" и до пробелов
                                        for (int i = 0; i < 37; i++)
                                        {
                                            if (arr_line[i] == ' ')
                                            {
                                                if (arr_line[i + 1] == ' ')
                                                    break;
                                                else
                                                    list_Transaction_Name_value.Add(arr_line[i]);
                                            }
                                            else
                                            {
                                                //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                                list_Transaction_Name_value.Add(arr_line[i]);
                                            }
                                        }
                                        //преобразовали в строку,где хранится значение Device Name:
                                        string_Transaction_Name_value_part_1 = new string(list_Transaction_Name_value.ToArray());
                                        //MessageBox.Show(string_Transaction_Name_value_part_1);

                                        List<char> list_Trans_value = new List<char>();
                                        List<char> list_Transaction_Amount_value = new List<char>();
                                        List<char> list_Discount_value = new List<char>();
                                        List<char> list_Account_Amount_value = new List<char>();
                                        for (int j = index_Trans_Date; j <= (end_line - 1); j++)
                                        {
                                            if (arr_line[j] == ' ')
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                if (count_column == 0)
                                                {
                                                    list_Trans_value.Add(arr_line[j]);
                                                    if (arr_line[j + 1] == ' ')
                                                    {
                                                        string_Trans_value = new string(list_Trans_value.ToArray());
                                                        count_column++;
                                                    }
                                                }
                                                else if (count_column == 1)
                                                {
                                                    list_Transaction_Amount_value.Add(arr_line[j]);
                                                    if (arr_line[j + 1] == ' ')
                                                    {
                                                        string_Transaction_Amount_value = new string(list_Transaction_Amount_value.ToArray());
                                                        count_column++;
                                                    }
                                                }
                                                else if (count_column == 2)
                                                {
                                                    list_Discount_value.Add(arr_line[j]);
                                                    if (arr_line[j + 1] == ' ')
                                                    {
                                                        string_Discount_value = new string(list_Discount_value.ToArray());
                                                        count_column++;
                                                    }
                                                }
                                                else if (count_column == 3)
                                                {
                                                    list_Account_Amount_value.Add(arr_line[j]);
                                                }

                                            }

                                        }
                                        count_column = 0;
                                        count_line = 1;
                                        string_Account_Amount_value = new string(list_Account_Amount_value.ToArray());
                                        MessageBox.Show(string_Trans_value);
                                        MessageBox.Show(string_Transaction_Amount_value);
                                        MessageBox.Show(string_Discount_value);
                                        MessageBox.Show(string_Account_Amount_value);
                                    }
                                    else if(count_line==1)
                                    {
                                        //создаем лист list_Transaction_Name_value для хранения значения Transaction Name:
                                        List<char> list_Transaction_Name_value_2 = new List<char>();
                                        for (int i = 0; i < end_line; i++)
                                        {
                                            if (arr_line[i] == ' ')
                                            {
                                                if (arr_line[i + 1] == ' ')
                                                    break;
                                                else
                                                    list_Transaction_Name_value_2.Add(arr_line[i]);
                                            }
                                            else
                                                list_Transaction_Name_value_2.Add(arr_line[i]);
                                        }
                                        string_Transaction_Name_value_part_2 = new string(list_Transaction_Name_value_2.ToArray());
                                        //MessageBox.Show(string_Transaction_Name_value_part_2);
                                        string_Transaction_Name_value = string_Transaction_Name_value_part_1 + string_Transaction_Name_value_part_2;
                                        MessageBox.Show(string_Transaction_Name_value);
                                        count_line = 0;
                                        list_Transaction_Name_value_2.Clear();
                                        flag = false;
                                        flag_Transaction = 1;
                                        /* string query = "Insert into " + TableName +
                                        " Values ('" +  + "')";

                                         //execute sqlcommand to insert record
                                         SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                                         myCommand.ExecuteNonQuery();*/
                                    }
                                }
                                else if(flag_Transaction==1 && line.StartsWith("             "))
                                {
                                    flag_Transaction = 0;
                                    continue;
                                }


                                
                                #endregion
                            }


                        }

                        //skip the header row
                        /* if (counter > 0)
                         {
                             //prepare insert query
                            
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
