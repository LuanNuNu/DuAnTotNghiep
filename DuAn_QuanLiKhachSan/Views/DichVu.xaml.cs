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
using BUS;
using System.Windows.Forms;

namespace DuAn_QuanLiKhachSan.Views
{
    /// <summary>
    /// Interaction logic for DichVu.xaml
    /// </summary>
    public partial class DichVu : Page
    {
        static BUS_DICHVU bUS_DichVu = new BUS_DICHVU();
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

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridDV.SelectedIndex;

            var row = (DataGridRow)dataGridDV.ItemContainerGenerator.ContainerFromIndex(index);
            DTO.DichVu dichVu = new DTO.DichVu();

            if (row != null)
            {
                var cell = dataGridDV.Columns[0].GetCellContent(row) as TextBlock;
                if (cell != null)
                {
                    dichVu = bUS_DichVu.TimKiem().Where(c => c.MaDV == cell.Text).FirstOrDefault();
                }
                cell = dataGridDV.Columns[1].GetCellContent(row) as TextBlock;
                if (cell != null)
                {
                    dichVu.TenDV = cell.Text;
                }

                cell = dataGridDV.Columns[3].GetCellContent(row) as TextBlock;
                if (cell != null)
                {
                    dichVu.GiaTien = double.Parse(cell.Text);
                }
            }
            var ThongBao = new DialogCustoms("Xác nhận thay đổi thông tin dịch vụ !", "Thông báo", DialogCustoms.YesNo);
            if (ThongBao.ShowDialog() == true)
            {
                bUS_DichVu.Update(dichVu);
                var ThongBao1 = new DialogCustoms("Cập nhật thành công", "Thông báo", DialogCustoms.OK);
                ThongBao1.ShowDialog();
                load();
            }
            else
            {
                var ThongBao1 = new DialogCustoms("Cập nhật thất bại!", "Thông báo", DialogCustoms.OK);
                ThongBao1.ShowDialog();
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
                    var ThongBao = new DialogCustoms("Bạn chắc chắn muốn xóa dịch vụ?", "Thông báo", DialogCustoms.YesNo);
                    if (ThongBao.ShowDialog() == true)

                        bUS_DichVu.Delete(cell.Text);
                    var ThongBao1 = new DialogCustoms("Xóa dịch vụ thành công!", "Thông báo", DialogCustoms.OK);
                    ThongBao1.ShowDialog();
                }
                    else
                    {
                    var ThongBao1 = new DialogCustoms("Xóa dịch vụ thất bại!", "Thông báo", DialogCustoms.OK);
                    ThongBao1.ShowDialog();
                    return;
                    }
            }
            load();
        }


        private void ___No_Name__Loaded(object sender, RoutedEventArgs e)
        {
            load();
        }
   
         private void ChildWindowClosed(object sender, EventArgs e)
        {
            // Handle child window closed event here
            load();
        }


        public void load()
        {
            dataGridDV.ItemsSource = bUS_DichVu.SelectDichVu().ToList();
        }

        private void txt_searchRoom_TextChanged(object sender, TextChangedEventArgs e)
        {

            var timkiem = txt_searchRoom.Text.ToLower();
            List<DTO.DichVu> result = bUS_DichVu.TimKiem().Where(c => c.TenDV.ToLower().Contains(timkiem)).ToList();
            dataGridDV.ItemsSource = result;
        }


    }


}


