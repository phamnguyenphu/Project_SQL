using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQL.DAO
{
    public class KhachHangDA
    {
        private static KhachHangDA instance;

        public static KhachHangDA Instance
        {
            get { if (instance == null) instance = new KhachHangDA(); return KhachHangDA.instance; }
            private set { KhachHangDA.instance = value; }
        }


        private KhachHangDA() { }


        // Hàm get danh sách nhân viên
        public DataTable danhSachKhachHang()
        {

            string query = "select * from User_info where roleAccount != 2 and roleAccount != 3";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;

        }

        //Hàm thêm Khách hàng

        public bool insertKhachHang(string name, DateTime birth, string sex, string phoneNumber, string email, string address, int chucVu)
        {
            
            string query = string.Format("Insert into User_info values(N'{0}','{1}',N'{2}','{3}','{4}',N'{5}','{6}')", name, birth, sex, phoneNumber, email, address, chucVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
