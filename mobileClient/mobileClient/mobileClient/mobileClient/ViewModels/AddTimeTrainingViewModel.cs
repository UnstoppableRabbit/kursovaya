using System.Collections.ObjectModel;
using System.Linq;
using DataLib.Sqlite;
using DataLib.Sqlite.Model;
using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class AddTimeTrainingViewModel : BaseViewModel
    {

        public AddTimeTrainingViewModel()
        {
            Trainings = new ObservableCollection<Training>();
        }

        private string type;
        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        private string itemId;
        public string ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public ObservableCollection<Training> Trainings { get; set; }

        public void LoadItemId(string itemId)
        {
            try
            {
                Type = itemId;
                if (Type == "Упражнения на время")
                {
                    Trainings.Clear();
                    foreach (var tr in ProductContext.Trainings.GetItems()
                        .Where(_ => !_.IsRepeated))
                    {
                        Trainings.Add(tr);
                    }
                }
                else
                {
                    Trainings.Clear();
                    foreach (var tr in ProductContext.Trainings.GetItems()
                        .Where(_ => _.IsRepeated))
                    {
                        Trainings.Add(tr);
                    }
                }
            }
            catch
            {
                //zxc
            }
        }
    }
}
