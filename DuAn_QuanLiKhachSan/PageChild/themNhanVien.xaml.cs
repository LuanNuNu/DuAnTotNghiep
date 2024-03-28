using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
    /// Interaction logic for themNhanVien.xaml
    /// </summary>
    public partial class themNhanVien : Window
    {
        public themNhanVien()
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
        private void Btn_Picture_Click_1(object sender, RoutedEventArgs e)
        {

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.WEBP; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.WEBP; *.gif; *.bmp";
                openFileDialog1.InitialDirectory = @"D:\C# NET102\ASM_Win\img";
                /*openFileDialog1.Title = "img";*/
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedFileName = openFileDialog1.FileName;
   
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(selectedFileName);
                    bitmap.EndInit();
                    ImageViewer1.Source = bitmap;
                }

                else
                {
                    // Người dùng đã hủy chọn ảnh, không cần tiếp tục
                    return;
                }
            }
        }
    }
}
