namespace LocationAPI.Models
{
    public class LocationResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }

    public class ApiResponseModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public LocationResponseModel Data { get; set; }


    }

}

/*
 "statusCode": "00",
  "statusMessage": "Success",
  "data": {
    "id": 1,
    "name": "NIGERIA",
    "twoLetterCode": "NG",
    "threeLetterCode": "NGA",
    "dialingCode": "234",
    "isMerchBuyAvailable": true,
    "locationLevelOneName": "string",
    "locationLevelTwoName": "string",
    "locationLevelThreeName": "string"
  },
  "error": null
 */
