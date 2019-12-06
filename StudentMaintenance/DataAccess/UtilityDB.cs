using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentMaintenance.DataAccess
{
    class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            SqlConnection connDB = new SqlConnection();

            connDB.ConnectionString = @"server=LAPTOP-8HGHP6AM;database=StudentDB;user=sa;password=kanwar";
            connDB.Open();
            return connDB;
        }
    }
}
