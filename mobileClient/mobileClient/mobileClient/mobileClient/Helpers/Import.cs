using System.Collections.Generic;
using System.Linq;
using DataLib.Sqlite;
using DataLib.Sqlite.Cache;
using mobileClient.Models;

namespace mobileClient.Helpers
{
    public static class Import
    {
        public static List<TrainingListElement> ToListTraningElement(this IEnumerable<TrainingCache> trList)
        {
            var result = new List<TrainingListElement>();
            var allTrainings = ProductContext.Trainings.GetItems();
            foreach (var training in trList)
            {
                if(allTrainings.FirstOrDefault(_ => _.Id.Equals(training.TrainingId)) != null)
                    result.Add(new TrainingListElement(allTrainings.First(_=>_.Id.Equals(training.TrainingId)), training.Points));
            }
            return result;
        }
    }
}
