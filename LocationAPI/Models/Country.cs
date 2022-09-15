namespace LocationAPI.Models
{
    public class CountryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string twoLetterCode { get; set; }
        public string threeLetterCode { get; set; }
        public string dialingCode { get; set; }
    }

    public class CountryApiResponseModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public CountryResponseModel Data { get; set; }
    }

    public class CountryListApiResponseModel
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
