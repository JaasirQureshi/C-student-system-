using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;


namespace Csharp_Student_System
{
    class STUDENT
    {
        MY_DB db = new MY_DB();

        public bool insertStudent(string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`first_name`, `last_name`, `birthdate`,`gender`, `phone`, `address`, `picture`)" +
                " VALUES (@fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", MySqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", MySqlDbType.LongBlob).Value = picture.ToArray();

            db.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
