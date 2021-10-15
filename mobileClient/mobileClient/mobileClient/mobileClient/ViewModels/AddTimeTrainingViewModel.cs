using Xamarin.Forms;

namespace mobileClient.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class AddTimeTrainingViewModel : BaseViewModel
    {
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

        public void LoadItemId(string itemId)
        {
            try
            {
                Type = itemId;
            }
            catch
            {
                //zxc
            }
        }
    }
}
