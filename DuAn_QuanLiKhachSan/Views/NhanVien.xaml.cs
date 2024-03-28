using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DuAn_QuanLiKhachSan.PageChild;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuAn_QuanLiKhachSan.Views
{
    /// <summary>
    /// Interaction logic for NhanVien.xaml
    /// </summary>
    public partial class NhanVien : Page
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void btn_nhanVien_Click(object sender, RoutedEventArgs e)
        {
            themNhanVien themNhanVien = new themNhanVien();
            /*    thongTinNVien thongTinNVien = new thongTinNVien();*/
            themNhanVien.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themNhanVien.Show();
        }
    }
}
