using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OnlineUrunSatis
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DCM13;Initial Catalog=DboOnlineUrunSatis;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
