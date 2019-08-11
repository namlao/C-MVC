using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaiAnhNam_baihat.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["QuanLyBaiHatConnectionString"].ConnectionString;

        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}