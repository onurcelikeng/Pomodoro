using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pomodoro
{
    public class NotificationViewModel : BaseViewModel
    {
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }


        public NotificationViewModel()
        {
            Title = "Notifications";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy) return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
			}

            catch (Exception)
			{
			}

			finally
			{
				IsBusy = false;
			}
		}
    }
}