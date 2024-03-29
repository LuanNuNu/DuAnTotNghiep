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
    public partial class frmTKDanhSachHoaDonNhapHang : Form
    {
        public frmTKDanhSachHoaDonNhapHang()
        {
            InitializeComponent();
        }

        private void frmDanhSachHoaDonBH_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Value = DateTime.Today;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;

            DataTable dt = new DataTable();
            dt = xemHoaDonNhap(DateTime.MaxValue, DateTime.MaxValue); // https://www.tutorialspoint.com/chash-datetime-max-value

            grdData.DataSource = dt;
            grdData.Refresh();
        }


        private DataTable xemHoaDonNhap(DateTime tuNgay, DateTime denNgay )
        {
            DataTable dt = new DataTable();
            string strSQL = " SELECT InOrders.InOrderID as [Mã hóa đơn], CONVERT(varchar, InOrders.InDate, 103) AS [Ngày hóa đơn], InOrders.Notes [Thông tin], InOrders.Total as [Tổng tiền], Employees.EmployeeName as [Nhân viên], Providers.Name as [Nhà cung cấp] " +
                        " FROM InOrders INNER JOIN " +
                        " Providers ON InOrders.ProviderID = Providers.ProviderID INNER JOIN " +
                        " Employees ON InOrders.EmployeeID = Employees.EmployeeID " + 
                        " where InOrders.InDate between '" + tuNgay + "' and  '" + denNgay + "'";
            using (SqlConnection conn = new SqlConnection(ConnectionString.getConnect()))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn))
                {
                    sda.Fill(dt);
                }
            }
            return dt;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = xemHoaDonNhap(dtpTuNgay.Value, dtpDenNgay.Value );
            grdData.DataSource = null;
            grdData.Refresh();
            grdData.DataSource = dt;
            grdData.Refresh();

        }
    }
}