namespace SlApi.General.Models
{
    public class ArrayBaseResult<T> : BaseResponse
    {
        /// <summary>
        /// Container-objekt som innehåller typad data
        /// </summary>
        public T[] Result { get; set; }
    }
}
