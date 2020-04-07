using System.Data.SqlClient;
using System.Windows.Forms;

namespace Report_system
{
    class Check
    {
        
        public int Check_Report(string File_name)
        {
           SqlConnection SQLConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'"
            };
            SQLConnection.Open();
            string Table_Name = "dbo.tbl_Result_Report_A";
            string query =
                "SELECT COUNT(*) FROM " +
                Table_Name +
                " WHERE " +
                " Name_of_report = '" + File_name+"'";
            string query2 =
                "SELECT COUNT(*) FROM " +
                Table_Name +
                " WHERE " +
                " Name_of_report = '" + File_name+"'"+
                " and Finish= '1'";
            try
            {
              
                //execute sqlcommand to insert record
                SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                // return 0 --- если этот отчёт ещё не добавлен
                // return 1 --- если отчёт успешно считан и добавлен в БД
                // return 2 --- если отчёт считан, но с ошибками или неполностью
                int rowcount = (int)myCommand.ExecuteScalar();
                if (rowcount>=1)
                {
                    myCommand = new SqlCommand(query2, SQLConnection);
                    rowcount = (int)myCommand.ExecuteScalar();
                    if(rowcount>=1)
                    {
                        SQLConnection.Close();
                        return 1;
                    }
                    else
                    {
                        SQLConnection.Close();
                        return 2;
                    }
                }
                else
                {
                    SQLConnection.Close();
                    return 0;
                }
                
            }
            catch (SqlException ex)
            {
                SQLConnection.Close();
                MessageBox.Show("Произошла ошибка при проверке" + ex);
                return 3;
            }
        }
    }
}
