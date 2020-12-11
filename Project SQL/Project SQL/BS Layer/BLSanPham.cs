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
    class BLSanPham
    {
        DBMain db = null;
        public string text;
        public BLSanPham()
        {
            db = new DBMain();
        }
        public DataSet LaySanPham()
        {
            return db.ExecuteQueryDataSet("EXEC proc_laythongtinsanpham", CommandType.Text);
        }
        public bool ThemSanPham(int idcategory, string name, decimal price, string model,
            string time, string origin, string decription, string url, string color, int seat, string fuel, ref string err)
        {
            string sqlstring = "EXEC proc_themsanpham " + idcategory + ",'" + name + "'," + price + ",'" + model + "','" +
                time + "','" + origin + "','" + decription + "','" + url + "','" +
                color + "'," + seat + ",'" + fuel + "'";

            return db.MyExecuteNonQuery(sqlstring, CommandType.Text, ref err);
        }
        public bool SuaSanPham(int idpd, int idcategory, string name, decimal price, string model,
           string time, string origin, string decription, string url, string color, int seat, string fuel, ref string err)
        {
            string sqlstring = "EXEC proc_suasanpham " + idpd + "," + idcategory + ",'" + name + "'," + price + ",'" + model + "','" + time + "','" + origin + "','" + decription + "','" + url + "','" +
                color + "'," + seat + ",'" + fuel + "'";
            text = sqlstring;
            return db.MyExecuteNonQuery(sqlstring, CommandType.Text, ref err);
        }

        public bool XoaSanPham(int idpd, ref string err)
        {
            string sqlstring = "EXEC proc_xoasanpham " + idpd;

            return db.MyExecuteNonQuery(sqlstring, CommandType.Text, ref err);
        }
    }
}
