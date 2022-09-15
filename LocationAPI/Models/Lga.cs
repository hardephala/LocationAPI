namespace LocationAPI.Models
{
    public class LgaResponseModel
    {
        public int Id { get; set; }
        public string locationLevelOneId { get; set; }
        public string name { get; set; }
    }

    public class LgaApiResponseModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public LgaResponseModel Data { get; set; }
    }

    public class LgaListApiResponseModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public ContentModel Data { get; set; }
        public class ContentModel
        {
            public List<StateResponseModel> Content { get; set; }
        }
    }
}
