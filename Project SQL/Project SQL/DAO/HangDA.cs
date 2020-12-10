using Project_SQL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQL.DAO
{
    public class HangDA
    {
        private static HangDA instance;

        public static HangDA Instance
        {
            get { if (instance == null) instance = new HangDA(); return HangDA.instance; }
            private set { HangDA.instance = value; }
        }


        private HangDA() { }
        public List<Hang> LayDanhSachHang()
        {
            List<Hang> list = new List<Hang>();

            string query = "select * from Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Hang Hang = new Hang(item);
                list.Add(Hang);
            }

            return list;

        }

        //Hàm thêm hãng
        public bool Insert_Hang(string name)
        {
            string query = string.Format("INSERT dbo.Category ( nameCategory )VALUES  ( N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


    }
}
