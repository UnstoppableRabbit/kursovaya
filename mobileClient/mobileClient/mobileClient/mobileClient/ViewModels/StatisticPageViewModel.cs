using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using DataLib.Mssql.Models;
using Microcharts;
using mobileClient.Models;
using mobileClient.Views;
using Newtonsoft.Json;
using SkiaSharp;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    public class StatisticPageViewModel : BaseViewModel
    {
        private string apiUrl = AppData.ApiUrl + "Statistic/";

        private List<PersonSportLog> personSports;
        private List<Diet> personDiets;

        private bool isVisible;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value, nameof(IsVisible));
        }

        private string weightLabel;
        public string WeightLabel { get => weightLabel; set => SetProperty(ref weightLabel, value); }

        private string caloriesLabel;
        public string CaloriesLabel { get => caloriesLabel; set => SetProperty(ref caloriesLabel, value); }

        public bool IsNotVisible => !IsVisible;

        private LineChart chart;
        public LineChart LineChart { get => chart; set => SetProperty(ref chart, value, nameof(LineChart)); }

        private BarChart barChart;
        public BarChart BarChart { get => barChart; set => SetProperty(ref barChart, value, nameof(BarChart)); }

        private List<ChartEntry> logEntries { get; set; } = new List<ChartEntry>();
        private List<ChartEntry> dietEntries { get; set; } = new List<ChartEntry>();

        private CurrentUser current;

        public StatisticPageViewModel()
        {
            current = CurrentUser.GetUser();
            CurrentUser.GetFromConfig(ref current);
            GetStatisticAsync();
            LineChart = new LineChart { Entries = logEntries, LabelOrientation = Orientation.Horizontal, ValueLabelOrientation = Orientation.Horizontal};
            BarChart = new BarChart { Entries = dietEntries, LabelOrientation = Orientation.Horizontal, ValueLabelOrientation = Orientation.Horizontal };
        }

        public async Task GetStatisticAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    // ReSharper disable once PossibleNullReferenceException
                    foreach (var log in JsonConvert.DeserializeObject<List<PersonSportLog>>(
                        await (await client.GetAsync(apiUrl + "log/" + current.Id)).Content.ReadAsStringAsync()))
                    {
                        logEntries.Add(new ChartEntry((float)log.Weight)
                        {
                            Color = SKColor.Parse("#9575CD"),
                            Label = log.Date.ToString("d"),
                            ValueLabel = log.Weight.ToString(CultureInfo.InvariantCulture)
                        });
                    }

                    if (logEntries.Count > 1)
                    {

                        var s = (DateTime.Parse(logEntries.Last().Label) - DateTime.Parse(logEntries.First().Label)).TotalDays;
                        var weightProgress = logEntries.Last().Value - logEntries.First().Value;
                        WeightLabel = weightProgress > 0 ? $"Ваш вес увеличелся на {weightProgress} кг за {s} {GetPostFix(s)}" : $"Ваш вес уменьшился на {Math.Abs(weightProgress)} кг за {s} {GetPostFix(s)}";
                    }

                    // ReSharper disable once PossibleNullReferenceException
                    foreach (var log in JsonConvert.DeserializeObject<List<Diet>>(
                        await (await client.GetAsync(apiUrl + "diet/" + current.Id)).Content.ReadAsStringAsync()))
                    {
                        dietEntries.Add(new ChartEntry((float)log.TotalCalories)
                        {
                            Color = SKColor.Parse("#9575CD"),
                            Label = log.Date.ToString("d"),
                            ValueLabel = log.TotalCalories.ToString(CultureInfo.InvariantCulture)
                        });
                    }

                    if (dietEntries.Count > 1)
                    {
                        var caloriesProgress = dietEntries[dietEntries.Count - 1].Value - dietEntries[dietEntries.Count - 2].Value;
                        CaloriesLabel = caloriesProgress > 0 ? $"Вы употребили на {caloriesProgress} каллорий больше чем в прошлый раз" : $"Вы употребили на {Math.Abs(caloriesProgress)} каллорий меньше чем в прошлый раз";
                    }

                }

                IsVisible = true;
                OnPropertyChanged(nameof(IsNotVisible));
            }
            catch
            {
                IsVisible = false;
                OnPropertyChanged(nameof(IsNotVisible));
            }
        }

        private string GetPostFix(double i)
        {
            if (((int) i).ToString().Last() == '1') return "день";
            if (((int) i).ToString().Last() == '2' || ((int) i).ToString().Last() == '3' ||
                ((int) i).ToString().Last() == '4') return "дня";
            else return "дней";
        }
        public ICommand SaveStatisticCommand => new Command(async () => await GoToSaveStatistic());
        public async Task GoToSaveStatistic()
        {
            await Shell.Current.GoToAsync($"//StatisticPage/{nameof(SaveStatisticPage)}");
        }
    }
}
