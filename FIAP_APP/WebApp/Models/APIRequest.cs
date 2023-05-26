using Microsoft.AspNetCore.Mvc;
using static App.Utility.SD;

namespace WebApp.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string ApiUrl { get; set; }

        public object Data { get; set; }
    }
}
