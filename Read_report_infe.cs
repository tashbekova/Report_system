using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{
    class Read_report_Infe
    {
        Connection sql = new Connection();
        private string ConnectionString = "";
        private BigInteger int_Report = 0;
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        public void Read_file(string path_name)
        {
            StreamReader SourceFile = File.OpenText(path_name);

            ConnectionString = sql.Get_Connection_String();
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string path_directory = (Path.GetDirectoryName(path_name));
            string file_name = (Path.GetFileNameWithoutExtension(path_name));
            DirectoryInfo di = Directory.CreateDirectory(path_directory + "/Report");
            string file_path = path_directory + "/Report/" + file_name + ".xls";
            try
            {
              
                SQLConnection.Open();
                Find_Report(file_name);
                excelapp = new Excel.Application();
                excelworkbook = excelapp.Workbooks.Open(path_name); //открываем наш файл    
               
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;

              
                

                excelworkbook.SaveAs(file_path);
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                excelworksheet.get_Range("I2", "I" + excelworksheet.UsedRange.Rows.Count).NumberFormat= "0";
                excelworksheet.get_Range("A2", "A" + excelworksheet.UsedRange.Rows.Count).NumberFormat = "m/d/yyyy";
                for (int i=2;i<=excelworksheet.UsedRange.Rows.Count;i++)
                {
                    if(excelworksheet.Cells[i,7].Value==null)
                    {
                        excelworksheet.Cells[i, 7] = 0;
                    }
                }
                excelworkbook.SaveAs(file_path);
                string excelConnString = String.Format("Provider=Microsoft.JET.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR = YES;IMEX=1\"", file_path);
             
                OleDbConnection Econ = new OleDbConnection(excelConnString);
                string Query = string.Format("Select DATE_PROVODKI_,SOURCE_DEVICE_,TYPE_,TRANS_DATE,SUMMA_,INTERCH_FEE_,CURR_,TARGET_NUMBER,TARGET_FI_ FROM [{0}]", file_name+"$");
                //string Query = string.Format("Select SUMMA_ FROM [{0}]", file_name + "$");
                OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                Econ.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                Econ.Close();
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];


                Exceldt.AcceptChanges();
                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(SQLConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "tbl_Report_Infe";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("DATE_PROVODKI_", "Posting_date");
                objbulk.ColumnMappings.Add("SOURCE_DEVICE_", "Device");
                objbulk.ColumnMappings.Add("TYPE_", "Type");
                objbulk.ColumnMappings.Add("TRANS_DATE", "Trans_date");
                objbulk.ColumnMappings.Add("SUMMA_", "Summa");
                objbulk.ColumnMappings.Add("INTERCH_FEE_", "[Interch_fee]");
                objbulk.ColumnMappings.Add("CURR_", "Currency");
                objbulk.ColumnMappings.Add("TARGET_NUMBER", "Target_number");
                objbulk.ColumnMappings.Add("TARGET_FI_", "Target_filial");
                //inserting Datatable Records to DataBase   
                objbulk.WriteToServer(Exceldt);
                MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update_Report(true, 1);

            }
            catch (Exception ex)
            {
                Update_Report(false, 2);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SourceFile.Close();
                SQLConnection.Close();

                //Показываем ексель
                //excelapp.Visible = true;

                //excelapp.Interactive = true;
                //excelapp.ScreenUpdating = true;
                //excelapp.UserControl = true;
                excelworkbook.Close(0);
                excelapp.Quit();
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                File.Delete(file_path); // удаление
                GC.Collect();
            }
        }
        private void Update_Report( bool flag_report, int finish)
        {
            //Create Connection to SQL Server
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string result;
            if (flag_report == true)
            {
                result = "Успешно считано и добавлено";
            }
            else
            {
                result = "Отчёт добавлен с ошибками или неполностью";
            }
            string Table_Name = "tbl_Result_Report_Infe";

            SQLConnection.Open();
            // запрос на добавление в SQL Server
            string query = "Update " + Table_Name +
                " Set Result='" + result + "'," +
                "Date_of_read='" + DateTime.Now + "'," +
                "Finish='" + finish + "'" +
                " Where " + Table_Name + ".ID='" + int_Report + "'";
            try
            {
                //execute sqlcommand to insert record
                SqlCommand command = new SqlCommand(query, SQLConnection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении названия отчёта в БД   " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        private BigInteger Find_Report(string File_name)
        {
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            SQLConnection.Open();
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
                return int_Report;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении названия отчёта в БД   " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        //Освобождаем ресуры (закрываем Excel)
        void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
