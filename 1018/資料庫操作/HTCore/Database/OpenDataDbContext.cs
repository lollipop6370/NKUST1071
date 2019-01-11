using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using HTCore.Models;

namespace HTCore.Database
{
    public class OpenDataDbContext : DbContext
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Source\Repos\NKUST10712\1018\資料庫操作\OpenDataImport\App_Data\Database1.mdf;Integrated Security=True";

            }

        }

        public DbSet<OpenData> OpenData { get; set; }



        public OpenDataDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


    }
}
