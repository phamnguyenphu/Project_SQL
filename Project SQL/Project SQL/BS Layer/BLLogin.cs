using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Project_SQL.DB_Layer;

namespace Project_SQL.BS_Layer
{
    class BLLogin
    {
        DBMain db = null;
        public BLLogin()
        {
            db = new DBMain();
        }
       

        public DataSet Login(string username, string password)
        {
            return db.ExecuteQueryDataSet("select * from func_dangnhaptaikhoan('" + username + "','" + password + "')", CommandType.Text);
        }



    }
}

