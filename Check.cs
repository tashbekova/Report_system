﻿using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Report_system
{
    public class Check
    {
        Connection sql = new Connection();
        string ConnectionString = "";
        public int Check_Report(string File_name)
        {
            ConnectionString = sql.Get_Connection_String();
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string Table_Name = "";
            if (File_name.Contains("Infe"))
            {
                Table_Name = "dbo.tbl_Result_Report_Infe";
            }
            else if (File_name.Contains('A'))
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
            SQLConnection.Open();
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
                MessageBox.Show("Произошла ошибка при проверке " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }
        }


        public int Check_Data(string Table_Name, int month, int year)
        {
            string column = "";
            if(Table_Name.StartsWith("tbl_Report"))
            {
                 column = "Posting_date";
            }
            else if (Table_Name.StartsWith("tbl_Result"))
            {
                column = "Date_of_read";
            }
                try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                myConnection.Open();
                string query =
                "SELECT COUNT(*) FROM " +
                Table_Name +
                " WHERE " +
                " Month("+column+")='" + month + "' and YEAR("+column+")= '" + year + "'";
                SqlCommand command = new SqlCommand(query, myConnection);
                int rowcount = (int)command.ExecuteScalar();
                myConnection.Close();
                return rowcount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }

        }

        public int Check_Data(string Table_Name)
        {
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                myConnection.Open();
                string query =
                "SELECT COUNT(*) FROM " + Table_Name;
                SqlCommand command = new SqlCommand(query, myConnection);
                int rowcount = (int)command.ExecuteScalar();
                myConnection.Close();
                return rowcount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }

        }

        public int Check_Data(string Table_Name,int year)
        {
            string column = "";
            if (Table_Name.StartsWith("tbl_Report"))
            {
                column = "Posting_date";
            }
            else if (Table_Name.StartsWith("tbl_Result"))
            {
                column = "Date_of_read";
            }
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                myConnection.Open();
                string query =
                "SELECT COUNT(*) FROM " +
                Table_Name +
                " WHERE " +
                "YEAR(" + column + ")= '" + year + "'";
                SqlCommand command = new SqlCommand(query, myConnection);
                int rowcount = (int)command.ExecuteScalar();
                myConnection.Close();
                return rowcount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 2;
            }

        }


        public int Check_Data(string Table_Name,int month,int month2, int year)
        {
            string column = "";
            if (Table_Name.StartsWith("tbl_Report"))
            {
                column = "Posting_date";
            }
            else if (Table_Name.StartsWith("tbl_Result"))
            {
                column = "Date_of_read";
            }
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                myConnection.Open();
                string query =
                "SELECT COUNT(*) FROM " +
                Table_Name +
                " WHERE " +
                "YEAR(" + column + ")= '" + year + "' and Month("+column+")>="+month+" and Month("+column+")<="+month2 ;
                SqlCommand command = new SqlCommand(query, myConnection);
                int rowcount = (int)command.ExecuteScalar();
                myConnection.Close();
                return rowcount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 2;
            }

        }
    }
}
