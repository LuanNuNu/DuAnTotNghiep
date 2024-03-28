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
    /// Interaction logic for DichVu.xaml
    /// </summary>
    public partial class DichVu : Page
    {
        public DichVu()
        {
            InitializeComponent();
        }

        private void btn_dichVu_Click(object sender, RoutedEventArgs e)
        {
            themDichVu themDichVu = new themDichVu();
            themDichVu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themDichVu.Show();
        }
    }
}
