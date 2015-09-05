namespace SlApi.Models
{
    public class ArrayBaseResponse<T> : BaseResponse
    {
        /// <summary>
        /// Container-objekt som innehåller typad data
        /// </summary>
        public T[] Result { get; set; }
    }
}
