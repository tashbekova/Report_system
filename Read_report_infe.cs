using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{
    class Read_report_Infe
    {
        string ConnectionString = "";
        string Table_Name = "";
        private BigInteger int_Report = 0;
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Sheets excelsheets;
        public void Read_file(string path_name)
        {
            StreamReader SourceFile = File.OpenText(path_name);
            string File_name = (Path.GetFileNameWithoutExtension(path_name));
            Connection sql = new Connection();
            ConnectionString = sql.Get_Connection_String();
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            try
            {
              
                SQLConnection.Open();
                Find_Report(File_name);
                excelapp = new Excel.Application();
                excelworkbook = excelapp.Workbooks.Open(path_name); //открываем наш файл    
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;
                excelsheets = excelworkbook.Worksheets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLConnection.Close();
                //Показываем ексель
                excelapp.Visible = true;

                excelapp.Interactive = true;
                excelapp.ScreenUpdating = true;
                excelapp.UserControl = true;
                GC.Collect();
            }
            //string string_Date_value = "";
            //string string_Device_value = "";
            //string string_Filial_value = "";
            //string string_Type_value = "";
            //string string_Summa_value = "";
            //string string_Currency_value = "";
            //string string_Target_number_value = "";
            //string string_Targer_Filial_value = "";
            //while (!SourceFile.EndOfStream)
            //{
            //    string line = SourceFile.ReadLine();
            //    char[] arr_line = line.ToCharArray();
            //    if (line.StartsWith("DATE"))
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        int end_line = line.Length;    //значение конца строки
            //        int count_column = 0;
            //        SQLConnection.Open();

            //List<char> list_Date = new List<char>();
            //List<char> list_Filial = new List<char>();
            //List<char> list_Device = new List<char>();
            //List<char> list_Type = new List<char>();
            //List<char> list_Summa = new List<char>();
            //List<char> list_Currency = new List<char>();
            //List<char> list_Target_Number = new List<char>();
            //List<char> list_Targer_Filial = new List<char>();

            //for(int i=0;i<10;i++)
            //{
            //    list_Date.Add(arr_line[i]);
            //}
            //string_Date_value = new string(list_Date.ToArray());

            //int index_Filial= line.IndexOf("SOURC", 0, end_line);
            //MessageBox.Show(index_Filial.ToString());
            //int index_fil=line.IndexOf("Halyk",0,end_line)
            ////for(int i=0;i<)

            //for (int j = 0; j <= (end_line - 1); j++)
            //{

            //    if (arr_line[j] == ' ' && arr_line[j + 1] == ' ')
            //    {
            //            continue;
            //    }
            //    else
            //    {
            //        if (count_column == 0)
            //        {
            //            list_Date.Add(arr_line[j]);
            //            if (arr_line[j + 1] == ' ' && arr_line[j + 2] == ' ')
            //            {
            //                string_Trans_Date_value = new string(list_Trans_Date_value.ToArray());
            //                count_column++;
            //            }
            //        }
            //        else if (count_column == 1)
            //        {
            //            if (arr_line[j] == ',')
            //                continue;
            //            else
            //                list_Number_Of_Trans_value.Add(arr_line[j]);
            //            if (arr_line[j + 1] == ' ')
            //            {
            //                string_Number_Of_Trans_value = new string(list_Number_Of_Trans_value.ToArray());

            //                count_column++;
            //            }
            //        }
            //        else if (count_column == 2)
            //        {
            //            if (arr_line[j] == ',')
            //                continue;
            //            else
            //                list_Transaction_Amount_value.Add(arr_line[j]);
            //            if (arr_line[j + 1] == ' ')
            //            {
            //                string_Transaction_Amount_value = new string(list_Transaction_Amount_value.ToArray());
            //                count_column++;
            //            }
            //        }
            //        else if (count_column == 3)
            //        {
            //            if (arr_line[j] == ',')
            //                continue;

            //            else
            //                list_Discount_value.Add(arr_line[j]);
            //            if (arr_line[j + 1] == ' ')
            //            {
            //                string_Discount_value = new string(list_Discount_value.ToArray());
            //                count_column++;
            //            }
            //        }
            //        else if (count_column == 4)
            //        {
            //            if (arr_line[j] == ',')
            //                continue;
            //            else
            //                list_Account_Amount_value.Add(arr_line[j]);
            //        }

            //    }
            //}
        }

        private void Find_Report(string File_name)
        {
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string Table_Name = "tbl_Result_Report_Infe";
            // запрос на добавление в SQL Server
            string query = "SELECT " + Table_Name + ".ID FROM  " + Table_Name +
                            "  WHERE " + Table_Name + ".Name_of_report='" + File_name + "'";
            try
            {
                //execute sqlcommand to insert record
                SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                BigInteger.TryParse((myCommand.ExecuteScalar().ToString()), out BigInteger ID_Report);
                int_Report = ID_Report;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении названия отчёта в БД   " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
