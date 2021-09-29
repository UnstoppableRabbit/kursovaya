using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DataLib.Sqlite;
using DataLib.Sqlite.Model;

namespace mobileClient.ViewModels
{
    public class TrainingPageViewModel : BaseViewModel
    {
        public ObservableCollection<Training> TrainingList { get; set; }

        public TrainingPageViewModel()
        {
            TrainingList = new ObservableCollection<Training>(ProductContext.Trainings.GetItems());
        }
    }
}
