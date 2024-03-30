using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DuAn_QuanLiKhachSan.PageChild;
using System.Windows.Controls;
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
    /// Interaction logic for DatPhong.xaml
    /// </summary>
    public partial class DatPhong : Page
    {
        public DatPhong()
        {
            InitializeComponent();
        }

        private void btn_datPhong_Click(object sender, RoutedEventArgs e)
        {
            thongtinPhong thongtinPhong = new thongtinPhong();
            phieuDatPhong phieuDatPhong = new phieuDatPhong();
            phieuDatPhong.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            phieuDatPhong.Show();
        }
    }
}
