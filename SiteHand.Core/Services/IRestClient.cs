using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using SiteHand.Core.Models;

namespace SiteHand.Core.Services
{
    public interface IRestClient
    {
        [Get("/volumes?q={searchCriteria}&printType={printType}")]
        Task<ResponseBooks> GetVolumes(string searchCriteria, string printType);

        [Get("/volumes/{idVolume}")]
        Task<Volume> GetVolume(string idVolume);
    }
}
