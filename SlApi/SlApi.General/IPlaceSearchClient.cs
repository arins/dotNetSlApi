using System.Threading.Tasks;
using SlApi.General.Models.PlaceSearch.Request;
using SlApi.General.Models.PlaceSearch.Response;

namespace SlApi.General
{
    /// <summary>
    /// Med detta API kan du få information om en plats genom att skicka in delar av platsens namn.
    /// Du kan välja mellan att bara söka efter hållplatsområden eller hållplatser, adresser och platser.
    /// </summary>
    public interface IPlaceSearchClient
    {


        /// <summary>
        /// Med detta API kan du få information om en plats genom att skicka in delar av platsens namn. 
        /// Du kan välja mellan att bara söka efter hållplatsområden eller hållplatser, adresser och platser.
        /// </summary>
        /// <param name="placeSearchRequest">Paramterar för sökning. Se information om parametrar i objektet</param>
        /// <returns>Platser (Sites)</returns>
        Sites Search(PlaceSearchRequest placeSearchRequest);

        /// <summary>
        /// Med detta API kan du få information om en plats genom att skicka in delar av platsens namn. 
        /// Du kan välja mellan att bara söka efter hållplatsområden eller hållplatser, adresser och platser.
        /// </summary>
        /// <param name="placeSearchRequest">Paramterar för sökning. Se information om parametrar i objektet</param>
        /// <returns>Platser (Sites)</returns>
        Task<Sites> SearchAsync(PlaceSearchRequest placeSearchRequest);
    }
}