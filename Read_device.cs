using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{

   
    class Read_device
    {
        Connection sql = new Connection();
        private string ConnectionString = "";
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;

        public void Read_device_infe(string path_name)
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
                excelapp = new Excel.Application();
                excelworkbook = excelapp.Workbooks.Open(path_name); //открываем наш файл    

                excelapp.Interactive = false;
                excelapp.EnableEvents = false;




                excelworkbook.SaveAs(file_path);
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];

                excelworkbook.Saved = true;
                string excelConnString = String.Format("Provider=Microsoft.JET.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR = YES;IMEX=1\"", file_path);

                OleDbConnection Econ = new OleDbConnection(excelConnString);
                string Query = string.Format("Select Device,Region FROM [{0}]",  "Лист1$");
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
                objbulk.DestinationTableName = "[dbo].[tbl_Pos_Region]";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("Region", "Region_Id");
                objbulk.ColumnMappings.Add("Device", "Device");
              
                //inserting Datatable Records to DataBase   
                objbulk.WriteToServer(Exceldt);
                MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
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
