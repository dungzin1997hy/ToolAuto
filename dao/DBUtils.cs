using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolTest.dao
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "quanlysimbox";
            string username = "root";
            string password = "123456";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}
