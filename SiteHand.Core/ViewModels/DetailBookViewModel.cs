using System;
using System.Threading.Tasks;
using System.Web;
using SiteHand.Core.Models;
using SiteHand.Core.Services;

namespace SiteHand.Core.ViewModels
{
    public class DetailBookViewModel : BaseViewModel
    {
        public Volume Volume { get; set; }
        public string MessageNotFound { get; set; }
        public bool IsNotFound { get; set; }
        private string IdVolume { get; set; }

        private readonly RestClient _restClient;

        public DetailBookViewModel(string idVolume)
        {

            IdVolume = idVolume;
            _restClient = new RestClient();

            Title = "Detail of Volume";
            MessageNotFound = "No detail available......";

            this.LoadDetail();
        }

        private async Task LoadDetail()
        {
            IsBusy = true;
            IsNotFound = false;

            try
            {
                Volume = await _restClient.GetVolume(IdVolume);                          
                if (Volume == null) { IsNotFound = true; }
            }
            catch (Exception)
            {
                IsNotFound = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
