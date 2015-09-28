namespace SlApi.General.Core
{
    public class Argument
    {
        public Argument()
        {
            UrlEncode = true;
        }

        public Argument(string value)
        {
            Value = value;
            UrlEncode = true;
        }

        public string Value { get; set; }
        public bool UrlEncode { get; set; }
    }
}