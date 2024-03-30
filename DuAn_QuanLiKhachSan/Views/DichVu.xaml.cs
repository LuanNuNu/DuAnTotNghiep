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
using BUS_QLKS;
using DTO_QLKS;
using System.Diagnostics;
using System.Security.Policy;

namespace DuAn_QuanLiKhachSan.Views
{
    /// <summary>
    /// Interaction logic for DichVu.xaml
    /// </summary>
    public partial class DichVu : Page
    {
       
        public static BUS_DichVu bUS_DichVu = new BUS_DichVu(); 
        public DichVu()
        {
            InitializeComponent();
            
        }
        private void ChildWindowClosed(object sender, EventArgs e)
        {
            // Handle child window closed event here
            load();
        }
        private void btn_dichVu_Click(object sender, RoutedEventArgs e)
        {
            themDichVu themDichVu = new themDichVu();
            themDichVu.ChildClosed += ChildWindowClosed;
            themDichVu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themDichVu.Show();
        }

        public void load()
        {
            dataGridDV.ItemsSource = bUS_DichVu.ViewGet().ToList();
        }

        private void ___No_Name__Loaded(object sender, RoutedEventArgs e)
        {
            load();
        }

        private void txt_searchRoom_TextChanged(object sender, TextChangedEventArgs e)
        {

            var timkiem = txt_searchRoom.Text.ToLower();
            List<DTO_QLKS.DichVu> result = bUS_DichVu.TimKiem().Where(c => c.TenDV.ToLower().Contains(timkiem)).ToList();
            dataGridDV.ItemsSource = result;
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridDV.SelectedIndex;

            var row = (DataGridRow)dataGridDV.ItemContainerGenerator.ContainerFromIndex(index); 
            DTO_QLKS.DichVu dichVu = new DTO_QLKS.DichVu();

            if(row != null)
            {
                var cell = dataGridDV.Columns[0].GetCellContent(row) as TextBlock;
                if(cell != null)
                {
                    dichVu = bUS_DichVu.TimKiem().Where(c=>c.MaDV == cell.Text).FirstOrDefault();
                }
                cell = dataGridDV.Columns[1].GetCellContent(row) as TextBlock;
                if (cell != null)
                {
                    dichVu.TenDV = cell.Text;
                }
                
                cell = dataGridDV.Columns[3].GetCellContent(row) as TextBlock;
                if (cell != null)
                {
                    dichVu.GiaTien = double.Parse( cell.Text);
                }
            }
            MessageBoxResult result = System.Windows.MessageBox.Show("Xác nhận thay đổi thông tin dịch vụ !", "Thông báo", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                bUS_DichVu.Update(dichVu);
                load();
            }
            else
            {
                return;
            }
        }

        private void Xoa_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridDV.SelectedIndex;

            if (index == -1)
            {
                // No item selected, nothing to delete
                return;
            }

            var row = (DataGridRow)dataGridDV.ItemContainerGenerator.ContainerFromIndex(index);

            if (row != null)
            {
                var cell = dataGridDV.Columns[0].GetCellContent(row) as TextBlock;
                if (cell != null)
                {
                    MessageBoxResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dịch vụ?", "Thông báo!!!", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Assuming bUS_DichVu is an instance of a class responsible for deleting items
                        // You might want to replace this with your actual method call to delete the item
                        bUS_DichVu.Delete(cell.Text);
                    }
                    else
                    {
                        // User canceled the deletion
                        return;
                    }
                }
            }

            // Assuming load() is a method to refresh the data grid after deletion
            load();
        }

    }
}
    