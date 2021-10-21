using DataLib.Sqlite.Model;

namespace mobileClient.Models
{
    public class TrainingListElement
    {
        public TrainingListElement(Training tr, int pts)
        {
            training = tr;
            if (tr.IsRepeated)
                Repeat = pts;
            else
                Seconds = pts;
        }
        private readonly Training training;

        public Training Training => training;
        public int Id => training.Id;
        public string Name => training.Name;
        public bool IsRepeated => training.IsRepeated;
        public string Measurement => IsRepeated ? $"{Repeat} повторений;" : $"{Seconds} секунд;";
        public double Calories => IsRepeated ? training.Calories * Repeat : (training.Calories / 60.0) * Seconds;
        public int Repeat { get; set; }
        public int Seconds { get; set; }

    }
}
