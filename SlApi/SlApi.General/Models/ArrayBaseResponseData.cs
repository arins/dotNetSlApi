namespace SlApi.General.Models
{
    public class ArrayBaseResponseData<T> : BaseResponse
    {
        /// <summary>
        /// Container-objekt som innehåller typad data
        /// </summary>
        public T[] ResponseData { get; set; }
    }
}