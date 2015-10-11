using System;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class Site
    {
        /// <summary>
        /// Unikt identifikationsnummer för en Site
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Benämning på området
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// Unikt identifikationsnummer för hållplats
        /// </summary>
        public int StopAreaNumber { get; set; }

        /// <summary>
        /// Senast ändrad
        /// </summary>
        public DateTime LastModifiedUtcDateTime { get; set; }

        /// <summary>
        /// Gäller fr.o.m. datum
        /// </summary>
        public DateTime ExistsFromDate { get; set; }

    }
}
