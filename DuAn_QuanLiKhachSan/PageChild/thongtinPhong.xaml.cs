using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuAn_QuanLiKhachSan.PageChild
{
    /// <summary>
    /// Interaction logic for thongtinPhong.xaml
    /// </summary>
    public partial class thongtinPhong : Window
    {
        public thongtinPhong()
        {
            InitializeComponent();
            checkIn.Text = DateTime.Now.ToString();

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_themDichVu_Click(object sender, RoutedEventArgs e)
        {
            themDichVuPhong themDichVuPhong = new themDichVuPhong();
            themDichVuPhong.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themDichVuPhong.Show();
        }
        private void btn_ThanhToan_Click(object sender, RoutedEventArgs e)
        {
            xuatHoaDon xuatHoaDon = new xuatHoaDon();
            xuatHoaDon.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            xuatHoaDon.Show();
        }

        private void btn_NhanPhong_Click(object sender, RoutedEventArgs e)
        {
            btn_NhanPhong.Visibility = Visibility.Hidden;
            btn_ThanhToan.Visibility = Visibility.Visible;
            btn_themDichVu.Visibility = Visibility.Visible;
        }
    }
}
