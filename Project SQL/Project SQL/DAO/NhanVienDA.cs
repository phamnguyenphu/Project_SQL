using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQL.DAO
{
    public class NhanVienDA
    {
        private static NhanVienDA instance;

        public static NhanVienDA Instance
        {
            get { if (instance == null) instance = new NhanVienDA(); return NhanVienDA.instance; }
            private set { NhanVienDA.instance = value; }
        }


        private NhanVienDA() { }

        // Hàm get danh sách nhân viên
        public DataTable danhSachNhanVien()
        {
            
            string query = "select * from User_info where roleAccount != 1";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;

        }

        //Hàm thêm nhân viên
        public bool insertNhanVien(string name, DateTime birth, string sex, string phoneNumber, string email, string address, int chucVu)
        {
            string query = string.Format("Insert into User_info values(N'{0}','{1}','{2}','{3}','{4}','{5}','{6}')", name, birth, sex, phoneNumber, email, address, chucVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Hàm Update nhân viên

        public bool updateNhanVien(string name, int id)
        {
            string query = string.Format("UPDATE dbo.Category SET nameCategory = N'{0}' WHERE idCategory = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Hàm xóa thông tin nhân viên
        public bool deleteNhanVien(int id)
        {
            string query = string.Format("Delete Category where idCategory = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable danhSachNhanVienById(int id)
        {

            string query = "exec getDataById @id", new object[] { id };

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;

        }

    }
}
