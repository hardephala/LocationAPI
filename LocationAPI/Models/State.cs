namespace LocationAPI.Models
{
    public class StateResponseModel
    {
        public int Id { get; set; }
        public string countryId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string capital { get; set; }
    }

    public class StateApiResponseModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public StateResponseModel Data { get; set; }
    }

    public class StateListApiResponseModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public ContentModel Data { get; set; }
        public class ContentModel
        {
            public List<CountryResponseModel> Content { get; set; }
        }
    }
}
