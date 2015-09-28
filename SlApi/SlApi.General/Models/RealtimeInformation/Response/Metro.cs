namespace SlApi.General.Models.RealtimeInformation.Response
{
    public class Metro : RealtimeInformationBase
    {
        /// <summary>
        /// Gruppering av metroavgångar per fysisk färdriktningsskylt på en plattform. 
        /// T.ex. grön linje vid tcentralen har två riktningar. Denna parameter kommer ha 
        /// 1 eller 2 för de olika riktningarna. Samma för röd och blå.
        /// </summary>
        public int DepartureGroupId { get; set; }
        
        /// <summary>
        /// Linjegruppering. Röd/grön/blå linje.
        /// </summary>
        public string GroupOfLine { get; set; }
        /// <summary>
        /// Linjegrupperingsid. Grön = 1. Röd = 2. Blå = 3.
        /// </summary>
        public int GroupOfLineId { get; set; }
        
        /// <summary>
        /// Informationsmeddelande för aktuell linjegrupp. Detta är det som syns på en
        ///  riktig skylt på en plattform. T.ex. ”Vänligen lämna plats för avstigande..”.
        /// </summary>
        public string PlatformMessage { get; set; }
        

    }
}