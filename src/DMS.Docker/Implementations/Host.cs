using DMS.Docker.Interfaces;
using System;
using System.Net.Http;
using DMS.Core.Models;

namespace DMS.Docker.Implementations
{
    public class Host : IHost
    {
        public Info Info(string hostAddress)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetStringAsync(string.Format("{0}/info", hostAddress));
                task.Wait();

                var result = task.Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Info>(result);
            }
        }

        public bool Ping()
        {
            throw new NotImplementedException();
        }
    }
}
