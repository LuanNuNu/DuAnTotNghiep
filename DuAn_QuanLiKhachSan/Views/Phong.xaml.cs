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
using System.Windows.Forms;

namespace DuAn_QuanLiKhachSan.Views
{
    /// <summary>
    /// Interaction logic for Phong.xaml
    /// </summary>
    public partial class Phong : Page
    {
        public Phong()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                lvPhongDon.ItemsSource = products;
                lvPhongDoi.ItemsSource = products;
                lvPhongGiaDinh.ItemsSource = products;
        }

        private void btn_themPhong_Click(object sender, RoutedEventArgs e)
        {
            themPhong themPhong = new themPhong();
            themPhong.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themPhong.Show();
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
      {
        new Product("P.101", 205.46, "/Assets/1.jpg"),
        new Product("P.102", 102.50, "/Assets/2.jpg"),
        new Product("P.103", 400.99, "/Assets/3.jpg"),
        new Product("P.104", 350.26, "/Assets/4.jpg"),
        new Product("P.105", 150.10, "/Assets/5.jpg"),
        new Product("P.201", 100.02, "/Assets/6.jpg"),
        new Product("P.202", 295.25, "/Assets/7.jpg"),
        new Product("P.203", 700.00, "/Assets/8.jpg")
      };
        }


        private void itemPhongDon_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            thongtinPhong thongtinPhong = new thongtinPhong();
            thongtinPhong.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            thongtinPhong.Show();
            System.Windows.Controls.ListView lv = sender as System.Windows.Controls.ListView;

        }
    }
}
