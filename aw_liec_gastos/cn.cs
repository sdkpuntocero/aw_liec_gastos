using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aw_liec_gastos
{
    public class cn
    {
        static string con_sql = @"Data Source=192.168.2.60;Initial Catalog=db_liec;User ID=u_liec;Password=dev_liec";
        static string con_postgreSQL = @"Server=192.168.3.200;Port=5432; User Id = development; Password=dev_.0;Database = db_liec";


        public static string cn_SQL
        {
            get
            {
                return con_sql;

            }
        }


        public static string cn_postgreSQL
        {
            get
            {
                return con_postgreSQL;

            }
        }
    }
}