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
    class Class_Report_A
    {
        string string_Financial_value = "";
        string string_Office_value = "";
        string string_Contract_value = "";
        string string_Region_value = "";
        string string_Currency_value = "";
        string string_Posting_Date_value = "";
        string string_Device_value = "";
        string string_SIC_value = "";
        string string_Cycle_value = "";
        string string_Device_Name_value = "";
        string string_Transaction_Name_value = "";
        string string_Trans_Date_value = "";
        string string_Number_Of_Trans_value = "";
        string string_Transaction_Amount_value = "";
        string string_Transaction_Name_value_part_1 = "";
        string string_Discount_value = "";
        string string_Account_Amount_value = "";

        int count_column = 0;
        int index_Trans_Date = 0;
        int end_line = 0;
        int count_Transaction_line = 0;
        int flag_Transaction = 0;

        //Create Connection to SQL Server
        SqlConnection SQLConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'"
            };


        public void Read_file(string path_name)
        {
            StreamReader SourceFile = File.OpenText(path_name);
            //string[] stroka = File.ReadAllLines(path_name);

            MessageBox.Show("Отчёт по банкоматам");

            //provide the table name in which you would like to load data
            string Table_Name = "";

            bool flag_indeks_Transaction = false;
            bool flag_Total_Posting_Date = false;
            bool flag_Total_Cycle = false;
            bool flag_Total_Device = false;
            bool flag_Total_Currency = false;
            bool flag_Total = false;
            bool flag_Add = false;

            SQLConnection.Open();

            while (!SourceFile.EndOfStream)
            {
                string line = SourceFile.ReadLine();
                if (line.StartsWith(" --------"))
                {
                    continue;
                }
                else
                {
                    //MessageBox.Show(line);

                    //объявление и инициализация переменных

                    end_line = line.Length;    //значение конца строки
                    int index_probel = line.IndexOf("     ", 0, end_line);   //индекс нахождения пробелов
                    //переводим строку в массив ,где будет хранится эта строка
                    char[]arr_line = line.ToCharArray();

                    // -------------------------------------------------------------------

                    #region Financial Institution
 
                    int index_Financial = line.IndexOf("Institution:", 0, end_line);  //индекс нахождения Financial Institution
                    //Если это строка с Financial Institution
                    if (index_Financial >= 0)
                    {
                        Read_Financial(arr_line,index_Financial,index_probel);
                    }
                    #endregion

                    
                    #region Office

                    int index_Office = line.IndexOf("Office:", 0, end_line);  //индекс нахождения Office
                     //Если это строка с Office
                    if (index_Office >= 0)
                    {
                        Read_Office(arr_line, index_Office);
                    }
                    #endregion


                    #region Contract

                    int index_Contract = line.IndexOf("Contract #:", 0, end_line);  //индекс нахождения Contract
                                                                                //Если это строка с Contract
                    if (index_Contract >= 0)
                    {
                        Read_Contract(arr_line, index_Contract);
                    }
                    #endregion


                    #region Region

                    int index_Region = line.IndexOf("Reg #:", 0, end_line);  //индекс нахождения Region
                     //Если это строка с "Reg #:"
                    if (index_Region >= 0)
                    {
                        Read_Region(arr_line, index_Region);
                    }
                    #endregion


                    #region Currency

                    int index_Currency = line.IndexOf("Currency:", 0, end_line);  //индекс нахождения Currency
                     //Если это строка с "Currency:"
                    if (index_Currency >= 0)
                    {
                        Read_Currency(arr_line, index_Currency);
                    }
                    #endregion


                    #region Device

                    int index_Device = line.IndexOf("Device:", 0, end_line);  //индекс нахождения Device
                    //Если это строка с Device:
                    if (index_Device >= 0)
                    {
                        Read_Device(arr_line, index_Device);
                    }
                    #endregion


                    #region SIC
                    
                    int index_SIC = line.IndexOf("SIC:", 0, end_line);  //индекс нахождения SIC
                    //Если это строка с SIC:
                    if (index_SIC >= 0)
                    {
                        Read_SIC(arr_line, index_SIC);
                    }
                    #endregion


                    #region Cycle Num/Type

                    int index_Cycle = line.IndexOf("Cycle Num/Type:", 0, end_line);  //индекс нахождения Cycle Num/Type:
                    //Если это строка с Cycle Num/Type:
                    if (index_Cycle >= 0)
                    {
                        Read_Cycle(arr_line, index_Cycle);
                    }
                    #endregion


                    #region Device Name:

                    int index_Device_Name = line.IndexOf("Device Name:", 0, end_line);  //индекс нахождения Device Name:
                    //Если это строка с Device Name:
                    if (index_Device_Name >= 0)
                    {
                        Read_Device_Name(arr_line, index_Device_Name);
                    }
                    #endregion


                    #region Posting Dates

                    int index_Posting_Date = line.IndexOf("Posting Date:", 0, end_line);  //индекс нахождения Posting Date
                    //Если это строка с Posting Date
                    if (index_Posting_Date >= 0)
                    {
                        Read_Posting_Date(arr_line, index_Posting_Date);
                        
                    }
                    #endregion

                    #region Transaction:

                    int index_Transaction_Name = line.IndexOf("Transaction Name", 0, end_line);
                    //Если это строка с Transaction Name
                    if (index_Transaction_Name >= 0)
                    {
                        index_Trans_Date = line.IndexOf("Trans Date", 0, end_line);
                        flag_indeks_Transaction = true;
                        continue;
                    }

                    //Если больше нет транзакций
                    if (flag_Transaction == 1 && arr_line.Length == 0 && flag_indeks_Transaction == true)
                    {
                        // Если больше нет транзакций,то обнуляем
                        flag_indeks_Transaction = false;
                        flag_Transaction = 0;
                       // MessageBox.Show("Больше нет транзакций,переходим к следующему");
                        continue;
                    }
                    //Если название Transaction Name состоит из одной строки
                    else if(flag_indeks_Transaction == true && count_Transaction_line == 1 && arr_line.Length==0)
                    {
                        flag_Transaction = 1;
                        count_Transaction_line = 0;
                        string_Transaction_Name_value = string_Transaction_Name_value_part_1;
                        Add_Data();
                    }
                    //Если еще не считывали , то считываем строку с данными о транзакции
                    else if (flag_indeks_Transaction == true && count_Transaction_line == 0 && !line.StartsWith("          "))
                    {
                        Read_Transaction_part_1(arr_line);
                    }
                    //Если Transaction_Name состоит из двух строк
                    else if (flag_indeks_Transaction == true && count_Transaction_line == 1 && !line.StartsWith("          "))
                    {
                        Read_Transaction_part_2(arr_line);
                        //Добавление данных  в БД
                        Add_Data();
                    }
                    #endregion 


                    #region Total 
                    //присвоение значений переменным
                    int index_Total_Date = line.IndexOf("TOTAL this Posting Date", 0, end_line);  //индекс нахождения Total Posting Date
                    int index_Total_For_Cycle = line.IndexOf("TOTAL for Cycle", 0, end_line);
                    int index_Total_Device = line.IndexOf("TOTAL this Device", 0, end_line);
                    int index_Total_Currency = line.IndexOf("TOTAL this Currency", 0, end_line);

                    //Если это строка с Total 
                    if (index_Total_Date >= 0)
                    {
                        flag_Total_Posting_Date = true;
                        flag_Total = true;
                    }
                    else if(index_Total_For_Cycle>=0)
                    {
                        flag_Total_Cycle = true;
                        flag_Total = true;
                    }
                    else if(index_Total_Device>=0)
                    {
                        flag_Total_Device = true;
                        flag_Total = true;
                    }
                    else if(index_Total_Currency>=0)
                    {
                        flag_Total_Currency = true;
                        flag_Total = true;
                    }

                    if(flag_Total==true)
                    {
                        if(flag_Total_Posting_Date==true)
                        {
                            Table_Name = "dbo.tbl_Total_Posting_Date_Report_A";
                        }
                        else if(flag_Total_Cycle==true)
                        {
                            Table_Name = "dbo.tbl_Total_for_Cycle_Report_A";
                        }
                        else if(flag_Total_Device==true)
                        {
                            Table_Name = "dbo.tbl_Total_Device_Report_A";
                        }
                        else if(flag_Total_Currency==true)
                        {
                            Table_Name = "dbo.tbl_Total_Currency_Report_A";
                        }
                        //создаем листы 
                        List<char> list_Number_Of_Trans_value = new List<char>();
                        List<char> list_Transaction_Amount_value = new List<char>();
                        List<char> list_Discount_value = new List<char>();
                        List<char> list_Account_Amount_value = new List<char>();

                        int index_number_of_trans = line.IndexOf("Number of Trans:", 0, end_line);
                        if (index_number_of_trans >= 0)
                        { ///Проходим по циклу начиная после слов "Number_Of_Trans" и до пробелов
                            for (int i = index_number_of_trans + 16; i < end_line; i++)
                            {
                                if (arr_line[i] == ' ')
                                {
                                    continue;
                                }
                                else if (arr_line[i] != ' ')
                                {
                                    //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                    list_Number_Of_Trans_value.Add(arr_line[i]);
                                }

                            }
                            string_Number_Of_Trans_value = new string(list_Number_Of_Trans_value.ToArray());
                            //MessageBox.Show(string_Number_Of_Trans);

                        }

                        int index_Transaction_Amount = line.IndexOf("Transaction Amount:", 0, end_line);
                        if (index_Transaction_Amount >= 0)
                        {
                            for (int i = index_Transaction_Amount + 19; i < end_line; i++)
                            {
                                if (arr_line[i] == ' ' || arr_line[i] == ',')
                                {
                                    continue;
                                }
                                else if (arr_line[i] != ' ')
                                {
                                    //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                    list_Transaction_Amount_value.Add(arr_line[i]);
                                }

                            }
                            string_Transaction_Amount_value = new string(list_Transaction_Amount_value.ToArray());
                            //MessageBox.Show(string_Transaction_Amount_value);
                        }

                        int index_Discount = line.IndexOf("Discount:", 0, end_line);
                        if(index_Discount>=0)
                        {
                            for (int i = index_Discount + 9; i < end_line; i++)
                            {
                                if (arr_line[i] == ' ' || arr_line[i] == ',')
                                {
                                    continue;
                                }
                                else if (arr_line[i] != ' ')
                                {
                                    //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                    list_Discount_value.Add(arr_line[i]);
                                }

                            }
                            string_Discount_value = new string(list_Discount_value.ToArray());
                           // MessageBox.Show(string_Discount_value);
                        }

                        int index_Account_Amount = line.IndexOf("Account Amount:", 0, end_line);
                        if(index_Account_Amount>=0)
                        {
                            for (int i = index_Account_Amount + 15; i < end_line; i++)
                            {
                                if (arr_line[i] == ' ' || arr_line[i] == ',')
                                {
                                    continue;
                                }
                                else if (arr_line[i] != ' ')
                                {
                                    //добавляем все символы в лист,чтобы получить массив и преобразовать в строку
                                    list_Account_Amount_value.Add(arr_line[i]);
                                }

                            }
                            string_Account_Amount_value = new string(list_Account_Amount_value.ToArray());
                           // MessageBox.Show(string_Account_Amount_value);
                            flag_Total = false;
                            flag_Total_Currency = false;
                            flag_Total_Cycle = false;
                            flag_Total_Device = false;
                            flag_Total_Posting_Date = false;

                            // запрос на добавление в SQL Server
                            string query = "Insert into " + Table_Name +
                                " (Date," +
                                " Device," +
                                " Device_name," +
                                "Number_of_trans," +
                                "Transaction_amount," +
                                "Discount," +
                                "Account_amount)" +
                                " Values ('" + string_Posting_Date_value + "','" +
                           string_Device_value + "','" +
                           string_Device_Name_value + "','" +
                           string_Number_Of_Trans_value + "','" +
                           string_Transaction_Amount_value + "','" +
                           string_Discount_value + "','" +
                           string_Account_Amount_value + "')";
                            try
                            {
                                //execute sqlcommand to insert record
                                SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                                myCommand.ExecuteNonQuery();
                               // MessageBox.Show("Добавлен Total");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Во время соединения произошла ошибка" + ex);
                            }
                        }

                        //преобразовали в строку,где хранится значение Number Of Trans
                       
                        list_Number_Of_Trans_value.Clear();
                        list_Transaction_Amount_value.Clear();
                        list_Discount_value.Clear();
                        list_Account_Amount_value.Clear();  
                    }
                   
                    #endregion
                }


            }



            SourceFile.Close();
            SQLConnection.Close();

        }

        public void Read_Financial(char[] arr_line,int index_Financial,int index_probel)
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
            list_Financial_value.Clear();
            //MessageBox.Show(string_Financial_value);
        }

        public void Read_Office(char[] arr_line,int index_Office)
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
            //MessageBox.Show(string_Office_value);
        }

        public void Read_Contract(char[] arr_line, int index_Contract)
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
            //MessageBox.Show(string_Contract_value);
        }

        public void Read_Region(char[] arr_line, int index_Region)
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
            //MessageBox.Show(string_Region_value);
        }

        public void Read_Currency(char[] arr_line,int index_Currency)
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
            //MessageBox.Show(string_Currency_value);
        }


        public void Read_Device(char[] arr_line,int index_Device)
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
            // MessageBox.Show(string_Device_value);
        }

        public void Read_SIC(char[] arr_line,int index_SIC)
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
            // MessageBox.Show(string_SIC_value);
        }


        public void Read_Cycle(char[] arr_line, int index_Cycle)
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
            // MessageBox.Show(string_Cycle_value);
        }


        public void Read_Device_Name(char[] arr_line,int index_Device_Name)
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
            // MessageBox.Show(string_Device_Name_value);
        }

        public void Read_Transaction_part_1(char[] arr_line)
        {
            //создаем лист list_Transaction_Name_value для хранения значения Transaction Name:
            List<char> list_Transaction_Name_value = new List<char>();
            //Проходим по циклу начиная после слов "Transaction Name:" и до пробелов
            for (int i = 0; i < index_Trans_Date; i++)
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
            //преобразовали в строку,где хранится значение Transaction Name:
            string_Transaction_Name_value_part_1 = new string(list_Transaction_Name_value.ToArray());
            //MessageBox.Show(string_Transaction_Name_value_part_1);

            List<char> list_Trans_Date_value = new List<char>();
            List<char> list_Trans_value = new List<char>();
            List<char> list_Transaction_Amount_value = new List<char>();
            List<char> list_Discount_value = new List<char>();
            List<char> list_Account_Amount_value = new List<char>();

            #region ADD_TRansaction (Добаление значений транзакций из таблиц):
            //Добавляем значения транзакций в переменные
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
                        list_Trans_Date_value.Add(arr_line[j]);
                        if (arr_line[j + 1] == ' ')
                        {
                            string_Trans_Date_value = new string(list_Trans_Date_value.ToArray());
                            count_column++;
                        }
                    }
                    else if (count_column == 1)
                    {
                        if (arr_line[j] == ',')
                            continue;
                        else
                            list_Trans_value.Add(arr_line[j]);
                        if (arr_line[j + 1] == ' ')
                        {
                            string_Number_Of_Trans_value = new string(list_Trans_value.ToArray());

                            count_column++;
                        }
                    }
                    else if (count_column == 2)
                    {
                        if (arr_line[j] == ',')
                            continue;
                        else
                            list_Transaction_Amount_value.Add(arr_line[j]);
                        if (arr_line[j + 1] == ' ')
                        {
                            string_Transaction_Amount_value = new string(list_Transaction_Amount_value.ToArray());
                            count_column++;
                        }
                    }
                    else if (count_column == 3)
                    {
                        if (arr_line[j] == ',')
                            continue;

                        else
                            list_Discount_value.Add(arr_line[j]);
                        if (arr_line[j + 1] == ' ')
                        {
                            string_Discount_value = new string(list_Discount_value.ToArray());
                            count_column++;
                        }
                    }
                    else if (count_column == 4)
                    {
                        if (arr_line[j] == ',')
                            continue;
                        else
                            list_Account_Amount_value.Add(arr_line[j]);
                    }

                }


            }
            #endregion ADD_TRansaction (Добаление значений транзакций из таблиц):

            count_column = 0;
            count_Transaction_line = 1;
            string_Account_Amount_value = new string(list_Account_Amount_value.ToArray());
            //Очищаем листы
            list_Account_Amount_value.Clear();
            list_Discount_value.Clear();
            list_Transaction_Amount_value.Clear();
            list_Transaction_Name_value.Clear();
            list_Trans_value.Clear();
        }

        public void Read_Transaction_part_2(char[] arr_line)
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
            //добавляем вторую часть названия транзакции в массив
            string string_Transaction_Name_value_part_2 = new string(list_Transaction_Name_value_2.ToArray());

            //складываем две части и получаем одно полное название транзакции
            string_Transaction_Name_value = string_Transaction_Name_value_part_1 + string_Transaction_Name_value_part_2;
            //MessageBox.Show(string_Transaction_Name_value);

            //обнуляем count_line , значит мы уже добавили одну транзакцию, то есть взяли все значения одной транзакции полностью
            count_Transaction_line = 0;

            //Очищаем переменные для добавления новых значений
            list_Transaction_Name_value_2.Clear();

            //обнуляем флаг с индексом транзакции
            // flag_indeks_Transaction = false;
            //Если одна транзакция уже добавлена в БД,то делаем flag_transaction =1
            flag_Transaction = 1;
        }

        public void Read_Posting_Date(char[] arr_line, int index_Posting_Date)
        {
            //создаем лист list_Date_value для хранения значения Date
            List<char> list_Posting_Date_value = new List<char>();
            //Проходим по циклу начиная после слов "Period to" и до пробелов
            for (int i = index_Posting_Date + 13; i < end_line; i++)
            {
                if (arr_line[i] == ' ')
                {
                    continue;
                }
                else if (arr_line[i] != ' ')
                {
                    list_Posting_Date_value.Add(arr_line[i]);
                    if (arr_line[i + 1] == ' ')
                    {
                        break;
                    }
                }

            }
            //преобразовали в строку,где хранится значение Posting Date
            string_Posting_Date_value = new string(list_Posting_Date_value.ToArray());
            list_Posting_Date_value.Clear();
            //MessageBox.Show(string_Posting_Date_value);
        }


        public void Add_Data()
        {
            string Table_Name = "dbo.Table_A";
            // запрос на добавление в SQL Server
            string query = "Insert into " + Table_Name +
                " (Posting_date," +
                " Financial_institution," +
                " Office," +
                "Contract#," +
                "Reg#," +
                "Currency," +
                "Device," +
                "SIC," +
                "Cycle_num_type," +
            "Device_name," +
            "Transaction_name," +
            "Trans_date," +
            "Number_of_trans," +
           "Transaction_amount," +
           "Discount," +
           "Account_amount)" +
           " Values ('" + string_Posting_Date_value + "','" +
           string_Financial_value + "','" +
           string_Office_value + "','" +
           string_Contract_value + "','" +
           string_Region_value + "','" +
           string_Currency_value + "','" +
           string_Device_value + "','" +
           string_SIC_value + "','" +
           string_Cycle_value + "','" +
           string_Device_Name_value + "','" +
           string_Transaction_Name_value + "','" +
           string_Trans_Date_value + "','" +
           string_Number_Of_Trans_value + "','" +
           string_Transaction_Amount_value + "','" +
           string_Discount_value + "','" +
           string_Account_Amount_value + "')";
            try
            {
                //execute sqlcommand to insert record
                SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                myCommand.ExecuteNonQuery();
                //MessageBox.Show("Успешно");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Во время соединения произошла ошибка" + ex);
            }
        }
    }

}
