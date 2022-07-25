using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiect1
{
    public class DBConnection
    {
        public static string ServerAddr = "localhost,33341";

        public static string CnnString()
        {
            string auth = string.Format("User={0};Password={1}", "icsadmin", "ics101pass");
            return String.Format(@"Data Source={0};Initial Catalog={1};{2}", ServerAddr, "proiect", auth);
        }
    }
}