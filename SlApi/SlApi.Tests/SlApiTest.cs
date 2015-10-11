namespace SlApi.Tests
{
    public class SlApiTest
    {
        public HttpRequestMocker HttpRequestMocker { get; set; }

        public SlApiTest()
        {
            HttpRequestMocker = new HttpRequestMocker();
        }
    }
}