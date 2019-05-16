using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using SiteHand.Core.Models;
using SiteHand.Core.Services;
using Xamarin.Forms;

namespace SiteHand.Core.ViewModels
{
    public class ListBooksViewModel : BaseViewModel
    {
        private const string CONFIG_PRINT_TYPE = "Print_Type";

        public ObservableCollection<Volume> Items { get; set; }
        public string SearchCriteria { get; set; }
        public string MessageNotFound { get; set; }
        public bool IsNotFound { get; set; }

        public ICommand LoadItemsCommand { get; }
        public ICommand SearchBookCommand { get; }

        private readonly IRemoteConfig _remoteConfig;
        private readonly RestClient _restClient;

        public ListBooksViewModel(IRemoteConfig remoteConfig)
        {

            _remoteConfig = remoteConfig;
            _restClient = new RestClient();

            LoadItemsCommand = new Command(async () => await LoadItems(SearchCriteria), () => !IsBusy);
            SearchBookCommand = new Command(async () => await SearchBooksAsync(SearchCriteria), () => !IsBusy);

            Title = "List of Books";
            SearchCriteria = "";
            Items = new ObservableCollection<Volume>();
            MessageNotFound = "No book could be found......";
        }

        private async Task SearchBooksAsync(string searchCriteria)
        {
            await LoadItems(searchCriteria);
        }

        public void ClearModel()
        {
            Items.Clear();
            SearchCriteria = string.Empty;
            IsNotFound = false;
        }

        private async Task LoadItems(string searchCriteria)
        {
            IsBusy = true;
            IsNotFound = false;
            PrintType type = PrintType.all;

            try
            {
                Enum.TryParse(_remoteConfig.GetRemoteDataString(CONFIG_PRINT_TYPE), out type);
                var BookCollection = await _restClient.GetVolumes(searchCriteria, type);
                Items.Clear();
                foreach (var item in BookCollection.items)
                {
                    Items.Add(item);
                }
                if (Items.Count == 0) { IsNotFound = true; }
            }
            catch (Exception)
            {
                Items.Clear();
                IsNotFound = true;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
