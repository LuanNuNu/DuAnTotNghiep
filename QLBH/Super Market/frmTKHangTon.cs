using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Super_Market
{
    public partial class frmTKHangTon : Form
    {
        public frmTKHangTon()
        {
            InitializeComponent();
        }

        private void frmDanhSachHoaDonBH_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = xemTonSanPham();
            grdData.DataSource = dt;
        }


        private DataTable xemTonSanPham( )
        {
            DataTable dt = new DataTable();
            string strSQL = " SELECT ProductID as [Mã sản phẩm], Name as [Tên sản phẩm], UnitCalc as [Đơn vị tính], sellPrice as [Giá bán], totalImport as [Tổng nhập], totalSell as [Tổng bán], (totalImport- totalSell) as [Tồn] " +
                           " FROM Products ";
            using (SqlConnection conn = new SqlConnection(ConnectionString.getConnect()))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn))
                {
                    sda.Fill(dt);
                }
            }
            return dt;

        }

    }
}