using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Entity;
using CodedHomes.Models;
using System.Configuration;

namespace CodedHomes.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Home> Homes { get; set; }
        public DbSet<User> Users { get; set; }

        public static string ConnectionStringName
        {
            get {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

        public DataContext():base(nameOrConnectionString: DataContext.ConnectionStringName)
        {

        }
    }
}
