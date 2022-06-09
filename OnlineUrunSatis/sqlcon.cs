using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUrunSatis
{
    class sqlcon
    {
        public SqlConnection baglanti()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DCM13;Initial Catalog=OnlineUrunSatisWeb;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
