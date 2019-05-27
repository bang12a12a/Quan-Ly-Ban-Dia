using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiQuangBTL
{
    class KetNoi_Database
    {
        string strConn = "Data Source=DESKTOP-RROP9B3\\SQLEXPRESS;Initial Catalog=QLCuaHangBanDia;Integrated Security=True";
        SqlConnection sqlConn;
        SqlDataReader sqldr;
        void OpenConnect()
        {
            sqlConn = new SqlConnection(strConn);
            if (sqlConn.State != System.Data.ConnectionState.Open)
                sqlConn.Open();
        }
        void CloseConnection()
        {
            if (sqlConn.State != System.Data.ConnectionState.Closed)
                sqlConn.Close();
            sqlConn.Dispose();
        }
        public DataTable SelectData(string sqlSelect)
        {
            DataTable dtDuLieu = new DataTable();
            OpenConnect();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSelect, sqlConn);
            dataAdapter.Fill(dtDuLieu);
            CloseConnection();
            return dtDuLieu;
        }
        public void UpdateData(string sql)
        {
            OpenConnect();
            SqlCommand sqlCmm = new SqlCommand();
            sqlCmm.Connection = sqlConn;
            sqlCmm.CommandText = sql;
            sqlCmm.ExecuteNonQuery();
            CloseConnection();
        }
        public string LoadLable(string sql)
        {
            string ketqua="";
            
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            SqlCommand sqlcom = new SqlCommand(sql,sqlConn);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                ketqua = sqldr[0].ToString();
            }
            CloseConnection();
            return ketqua;
        }
        internal void UpdateData(object p)
        {
            throw new NotImplementedException();
        }
    }
}
