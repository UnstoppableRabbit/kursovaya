using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Microcharts;
using mobileClient.Views;
using SkiaSharp;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class StatisticPageVievModel : BaseViewModel
    {
        private LineChart chart;
        public LineChart Chart { get => chart; set => SetProperty(ref chart, value, nameof(Chart)); }

        public StatisticPageVievModel()
        {
            Chart = new LineChart() { Entries = new List<ChartEntry>{ new ChartEntry(20.1f){ Color = SKColor.Parse("#4B0082"), Label = DateTime.Now.AddDays(-2).ToString("dd.MM.yyyy"), ValueLabel = "220"}, new ChartEntry(22.3f) { Label = DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"), ValueLabel = "22", TextColor = SKColor.Parse("#000000"), ValueLabelColor = SKColors.Black }, new ChartEntry(11.2f) { ValueLabel = "wwq",Color = SKColor.Parse("#0000FF"), Label = DateTime.Now.ToString("dd.MM.yyyy") } }, LineMode = LineMode.Straight, LabelTextSize = 14, LabelColor = SKColors.Black, ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal};
        }

        public ICommand SaveStatisticCommand => new Command(async () => await GoToSaveStatistic());
        public async Task GoToSaveStatistic()
        {
            await Shell.Current.GoToAsync($"//StatisticPage/{nameof(SaveStatisticPage)}");
        }
    }
}
