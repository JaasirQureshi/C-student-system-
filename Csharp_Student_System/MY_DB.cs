using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Csharp_Student_System
{
    class MY_DB
    {
        private MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=csharp_student_db");

        public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }


        // open the connection
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
    }
}
