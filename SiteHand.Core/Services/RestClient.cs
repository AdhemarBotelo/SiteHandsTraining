using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using SiteHand.Core.Models;

namespace SiteHand.Core.Services
{
    public class RestClient
    {
        private readonly IRestClient _restClient;
        public RestClient()
        {
            _restClient = RestService.For<IRestClient>("https://www.googleapis.com/books/v1");
        }

        /// <summary>
        /// Get the Volumes according to the criteria
        /// </summary>
        /// <param name="searchCriteria">search criteria in the title field</param>
        /// <param name="printType">to define  if the search will be in books or magazine or both</param>
        /// <returns>List of Volumes</returns>
        public async Task<ResponseBooks> GetVolumes(string searchCriteria, PrintType printType = PrintType.all)
        {
            return await _restClient.GetVolumes(searchCriteria, printType.ToString());
            
        }

        /// <summary>
        /// Get a Volume according to an ID
        /// </summary>
        /// <param name="idVolume">the id of the volume</param>
        /// <returns>a Volume</returns>
        public async Task<Volume> GetVolume(string idVolume)
        {
            return await _restClient.GetVolume(idVolume);
        }
    }
}
