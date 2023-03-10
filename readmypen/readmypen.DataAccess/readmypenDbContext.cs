using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using readmypen.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace readmypen.DataAccess
{
    class readmypenDbContext : AppDbContext
    {
        public static string ConnectionString = "Data source=DESKTOP-N8HS364\\SQLEXPRESS; Initial Catalog=READMYPEN_NICKRAMEN; Persist Security Info=True; Trusted_Connection=yes;";

        public readmypenDbContext()
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public static void BuildConnectionString(string connectionString)
        {
            var connString = new SqlConnectionStringBuilder
            {
                ConnectionString = connectionString
            };

            ConnectionString = connString.ConnectionString;
        }

    }
}
