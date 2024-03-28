using BUS;
using DTO;
using DuAn_QuanLiKhachSan.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuAn_QuanLiKhachSan.PageChild
{
    /// <summary>
    /// Interaction logic for themDichVuPhong.xaml
    /// </summary>
    public partial class themDichVuPhong : Window
    {
        BUS_DICHVU BUS_DICHVU = new BUS_DICHVU();
        public delegate void Delegate_CTPDV(ObservableCollection<ListDichVu> obDVCT);
        public Delegate_CTPDV truyenData;
        ObservableCollection<ListDichVu> lsdichVu_Customs;
        ObservableCollection<ListDichVu> lsDichVu_DaChon;
        List<ListDichVu> lsCache;
        public themDichVuPhong()
        {
            InitializeComponent();

        }
        private void Load(object sender, RoutedEventArgs e)
        {
            // Khởi tạo danh sách dịch vụ chưa được chọn
            lsdichVu_Customs = new ObservableCollection<ListDichVu>(BUS_DICHVU.SelectDichVu().ToList());
            // Khởi tạo danh sách dịch vụ đã chọn
            lsDichVu_DaChon = new ObservableCollection<ListDichVu>();

            // Gán danh sách dịch vụ chưa được chọn làm ItemsSource cho danhSachDichVu
            danhSachDichVu.ItemsSource = lsdichVu_Customs;
            // Gán danh sách dịch vụ đã chọn làm ItemsSource cho dichVuDaChon
            dichVuDaChon.ItemsSource = lsDichVu_DaChon;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void addDichVu_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem sender có phải là một Button hay không
            if (sender is System.Windows.Controls.Button button)
            {
                // Lấy đối tượng được chọn từ DataContext của Button
                if (button.DataContext is ListDichVu dichvu)
                {
                    // Kiểm tra xem danh sách lsdichVu_Customs có được khởi tạo hay không
                    if (lsdichVu_Customs != null)
                    {
                        // Di chuyển dịch vụ từ danh sách chưa được chọn sang danh sách đã chọn
                        lsdichVu_Customs.Remove(dichvu);

                        // Kiểm tra xem danh sách lsDichVu_DaChon có được khởi tạo hay không
                        if (lsDichVu_DaChon != null)
                        {
                            // Thêm dịch vụ vào danh sách đã chọn
                            lsDichVu_DaChon.Add(dichvu);
                        }
                        else
                        {
                            // Không thêm dịch vụ vào danh sách đã chọn nếu danh sách này chưa được khởi tạo
                            System.Windows.MessageBox.Show("Danh sách dịch vụ đã chọn chưa được khởi tạo.");
                        }
                    }
                    else
                    {
                        // Không loại bỏ dịch vụ từ danh sách chưa được chọn nếu danh sách này chưa được khởi tạo
                        System.Windows.MessageBox.Show("Danh sách dịch vụ chưa được khởi tạo.");
                    }
                }
            }
        }

        private void removeDichVu_Click(object sender, RoutedEventArgs e)
        {
            ListDichVu dichvu = (sender as System.Windows.Controls.Button).DataContext as ListDichVu;

            if (dichvu != null)
            {
                // Xóa mục được chọn khỏi danh sách đã chọn
                lsDichVu_DaChon.Remove(dichvu);

                // Thêm mục được xóa vào danh sách chưa được chọn
                lsdichVu_Customs.Add(dichvu);


            }
        }

        private void searchDichVu_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView viewDV = (CollectionView)CollectionViewSource.GetDefaultView(danhSachDichVu.ItemsSource);
            viewDV.Filter = filterTimKiem;
        }
        private bool filterTimKiem(object obj)
        {
            if (String.IsNullOrEmpty(searchDichVu.Text))
                return true;
            else
            {
                string objTenDV = RemoveVietnameseTone((obj as ListDichVu).TenDV);
                string timkiem = RemoveVietnameseTone(searchDichVu.Text);
                return objTenDV.Contains(timkiem);
            }
        }
        public string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }

        private void cong_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button congButton = sender as System.Windows.Controls.Button;
            if (congButton != null)
            {
                // Lấy ra DataGridRow chứa nút 'cong'
                DataGridRow row = FindAncestor<DataGridRow>(congButton);
                if (row != null)
                {
                    // Tìm TextBox 'soLuong' trong DataGridRow
                    System.Windows.Controls.TextBox soLuongTextBox = FindChild<System.Windows.Controls.TextBox>(row, "soLuong");
                    if (soLuongTextBox != null)
                    {
                        int currentValue;
                        if (int.TryParse(soLuongTextBox.Text, out currentValue))
                        {
                            currentValue++;
                            soLuongTextBox.Text = currentValue.ToString();
                        }
                    }
                }
            }
        }

        private void tru_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button truButton = sender as System.Windows.Controls.Button;
            if (truButton != null)
            {
                // Lấy ra DataGridRow chứa nút 'tru'
                DataGridRow row = FindAncestor<DataGridRow>(truButton);
                if (row != null)
                {
                    // Tìm TextBox 'soLuong' trong DataGridRow
                    System.Windows.Controls.TextBox soLuongTextBox = FindChild<System.Windows.Controls.TextBox>(row, "soLuong");
                    if (soLuongTextBox != null)
                    {
                        int currentValue;
                        if (int.TryParse(soLuongTextBox.Text, out currentValue))
                        {
                            if (currentValue > 1)
                            {
                                currentValue--;
                                soLuongTextBox.Text = currentValue.ToString();
                            }
                        }
                    }
                }
            }
        }

        private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            } while (current != null);
            return null;
        }

        private T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Tìm kiếm tất cả các thành phần con của parent
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                // Kiểm tra xem thành phần con có phải là kiểu T không
                if (child != null && child is T && ((FrameworkElement)child).Name == childName)
                {
                    return (T)child;
                }
                else
                {
                    T result = FindChild<T>(child, childName);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }



    }
}
