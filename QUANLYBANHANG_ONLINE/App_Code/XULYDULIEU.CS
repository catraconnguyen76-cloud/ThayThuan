using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE
{
    public class XULYDULIEU
    {
        private SqlConnection con;

        public XULYDULIEU()
        {
            con = new SqlConnection();

            // Dang nhap SQL Server bang tai khoan sa.
            // Thay MAT_KHAU_CUA_BAN bang mat khau sa tren may ban.
            con.ConnectionString =
            @"Data Source=LAPTOP-1G03D4CO\SQLEXPRESS;Initial Catalog=dbQUANLYBANHANG;User ID=sa;Password=12345";
        }

        // Mo ket noi.
        private void MoKetNoi()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // Dong ket noi.
        private void DongKetNoi()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }

        // Lay bang du lieu bang cau lenh SQL.
        public DataTable getTable(string SQL)
        {
            try
            {
                MoKetNoi();

                DataTable tb = new DataTable();

                using (SqlDataAdapter adp = new SqlDataAdapter(SQL, con))
                {
                    adp.Fill(tb);
                }

                return tb;
            }
            finally
            {
                DongKetNoi();
            }
        }

        // Lay bang du lieu bang stored procedure.
        public DataTable getTable(
            string nameprocedurce,
            SqlParameter[] pr)
        {
            try
            {
                MoKetNoi();

                DataTable tb = new DataTable();

                using (SqlCommand cmd = new SqlCommand(nameprocedurce, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (pr != null)
                    {
                        cmd.Parameters.AddRange(pr);
                    }

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(tb);
                    }
                }

                return tb;
            }
            finally
            {
                DongKetNoi();
            }
        }

        // Them bang du lieu vao DataSet bang cau lenh SQL.
        public void getDataSet(ref DataSet ds, string SQL)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }

            ds.Tables.Add(getTable(SQL));
        }

        // Them bang du lieu vao DataSet bang stored procedure.
        public void getDataSet(
            ref DataSet ds,
            string nameprocedurce,
            SqlParameter[] pr)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }

            ds.Tables.Add(getTable(nameprocedurce, pr));
        }

        // Thuc hien INSERT, UPDATE, DELETE bang cau lenh SQL.
        // Tra ve so dong bi anh huong theo ExecuteNonQuery.
        public int ExeCute(string SQL)
        {
            try
            {
                MoKetNoi();

                using (SqlCommand cmd = new SqlCommand(SQL, con))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        // Thuc hien lenh bang stored procedure.
        public int ExeCute(
            string nameprocedurce,
            SqlParameter[] pr)
        {
            try
            {
                MoKetNoi();

                using (SqlCommand cmd = new SqlCommand(nameprocedurce, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (pr != null)
                    {
                        cmd.Parameters.AddRange(pr);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
        }
    }
}