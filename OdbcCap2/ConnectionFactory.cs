﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace OdbcCap2
{
    static class ConnectionFactory
    {
        public static OdbcConnection CreateConnection()
        {
            string driver = @"SQL Server";
            string servidor = @".\SQLEXPRESS";
            string baseDeDados = @"livraria";

            StringBuilder connectionString = new StringBuilder();
            connectionString.Append("driver=");
            connectionString.Append(driver);
            connectionString.Append(";server=");
            connectionString.Append(servidor);

            connectionString.Append(";database=");
            connectionString.Append(baseDeDados);
            connectionString.Append(";TrustedConnection=Yes");

            return new OdbcConnection(connectionString.ToString());
        }
    }
}
