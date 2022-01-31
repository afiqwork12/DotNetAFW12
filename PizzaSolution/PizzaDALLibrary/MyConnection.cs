﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PizzaDALLibrary
{
    //singleton class
    internal class MyConnection
    {
        SqlConnection conn;
        static MyConnection connection;
        private MyConnection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public static SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new MyConnection();
            return connection.conn;
        }
        ~MyConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
