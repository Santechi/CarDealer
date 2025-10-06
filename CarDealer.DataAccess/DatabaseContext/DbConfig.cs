using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.DatabaseContext
{
    public class DbConfig
    {
        public static string GetConnectionString()
        {
            return "User ID=postgres;Password=123;Host=localhost;Port=5432;Database=cardealerdb;";
        }
    }
}
