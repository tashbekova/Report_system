using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;


namespace Report_system
{
    class Class_Report_A
    {
        public void Read_file(string path_name)
        {
            StreamReader SourceFile = File.OpenText(path_name);
            //provide the table name in which you would like to load data
            //string table_name = "dbo.tbl_repA";
            //Create Connection to SQL Server
            SqlConnection SQLConnection = new SqlConnection();
            SQLConnection.ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
            SQLConnection.Open();

            SQLConnection.Close();

        }
    }

}
