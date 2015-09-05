namespace SlApi.Models
{
    public class ArrayBaseResponseData<T> : BaseResponse
    {
        /// <summary>
        /// Container-objekt som inneh�ller typad data
        /// </summary>
        public T[] ResponseData { get; set; }
    }
}