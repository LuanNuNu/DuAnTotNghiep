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
using System.Windows.Shapes;
using DuAn_QuanLiKhachSan.Views;

namespace DuAn_QuanLiKhachSan.PageChild
{
    /// <summary>
    /// Interaction logic for themDichVu.xaml
    /// </summary>
    public partial class themDichVu : Window
    {
        public themDichVu()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void themLoaiDichVu_Click(object sender, RoutedEventArgs e)
        {
            
            themLoaiDichVu themLoaiDichVu = new themLoaiDichVu();
            themLoaiDichVu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themLoaiDichVu.Show();
        }
    }
}
