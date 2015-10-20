using System.Threading.Tasks;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi
{
    /// <summary>
    /// Med detta API kan du f� information om den aktuella statusen f�r SLs trafikl�ge. 
    /// Detta �r information p� en �vergripande niv� om aktuell status f�r respektive trafikslag.
    /// Den information som ligger till grund f�r detta API hittar du p� startsidan av sl.se under 
    /// rubriken "Trafikl�get kl. xx:xx".
    ///
    /// API �et har endast en metod som returnerar en �versiktlig bild �ver hur trafiksituationen ser ut just nu,
    /// med avseende p� st�rningar som kan p�verka resen�rerna.Det som returneras �r en lista med ett antal trafikslag,
    /// varje trafikslag har en sammanfattande status och ett antal (0 eller fler) h�ndelser.
    ///
    /// Det finns 3 olika status som h�ndelser kan ha:
    ///
    /// �Inga st�rre st�rningar�
    /// �Stor p�verkan�
    /// �Avst�ngt�
    /// 
    /// En h�ndelse p�verkar sitt trafikslag, s� att trafikslagets sammanfattande status �r lika med den s�msta
    /// statusen som finns ibland just nu aktiva h�ndelser tillh�rande trafikslaget.En h�ndelse kan ut�ver
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