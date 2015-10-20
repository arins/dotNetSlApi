using System.Threading.Tasks;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi
{
    /// <summary>
    /// Med detta API kan du få information om den aktuella statusen för SLs trafikläge. 
    /// Detta är information på en övergripande nivå om aktuell status för respektive trafikslag.
    /// Den information som ligger till grund för detta API hittar du på startsidan av sl.se under 
    /// rubriken "Trafikläget kl. xx:xx".
    ///
    /// API ’et har endast en metod som returnerar en översiktlig bild över hur trafiksituationen ser ut just nu,
    /// med avseende på störningar som kan påverka resenärerna.Det som returneras är en lista med ett antal trafikslag,
    /// varje trafikslag har en sammanfattande status och ett antal (0 eller fler) händelser.
    ///
    /// Det finns 3 olika status som händelser kan ha:
    ///
    /// ”Inga större störningar”
    /// ”Stor påverkan”
    /// ”Avstängt”
    /// 
    /// En händelse påverkar sitt trafikslag, så att trafikslagets sammanfattande status är lika med den sämsta
    /// statusen som finns ibland just nu aktiva händelser tillhörande trafikslaget.En händelse kan utöver
    /// statusen dessutom vara planerad (bool).
    /// </summary>
    public interface ITrafficInformationClient
    {
        bool GzipEnabled { get; set; }
        bool EnableDebugInformationInException { get; set; }

        TrafficInformation GetTrafficInformation();

        Task<TrafficInformation> GetTrafficInformationAsync();
    }
}