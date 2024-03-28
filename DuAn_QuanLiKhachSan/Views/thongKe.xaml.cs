using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuAn_QuanLiKhachSan.Views
{
    /// <summary>
    /// Interaction logic for thongKe.xaml
    /// </summary>
    public partial class thongKe : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public thongKe()
        {

            InitializeComponent();
            this.PieChart();
            // Thiết lập dữ liệu của biểu đồ

            SeriesCollection = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "Doanh thu phòng",
                    Values = new ChartValues<double> { 0,14000000, 16000000, 11890000, 12000000 ,14200999, 12890000, 16000000,18700000,18100900,21000000,15000000,17000000 }
                },
                new LineSeries
                {
                    Title = "Doanh thu DV",
                    Values = new ChartValues<double> { 0, 4000000, 5500000, 8000000, 9800000 , 4900000, 8000000,6000000,2000000,5000000,3000000,9000000,2000000},
                    PointGeometry = DefaultGeometries.Circle,
 
                },
                new LineSeries
                {
                    Title = "SL phòng đặt",
                    Values = new ChartValues<double> {0, 123, 242, 117, 169 ,172, 154,137,193,155,261,331,291},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 15
                }

            };

            // Thiết lập nhãn cho trục X
            string[] tenThang = { "0", "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            Labels = tenThang;
            // Thiết lập DataContext
            DataContext = this;
        }
        public Func<ChartPoint, string>PointLabel { get; set; }
        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}%", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }
        /*   public void Cartesian()
           {
               SeriesCollection = new SeriesCollection
               {
                   new LineSeries
                   {
                       Title="Doanh thu phòng", Values = new ChartValues<double> {}
                   }
               }
           }*/
    }
}
