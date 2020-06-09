using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_system
{
    public class Connection
    {
            public string Get_Connection_String()
        {

            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
            return ConnectionString;
        }
    }
}
