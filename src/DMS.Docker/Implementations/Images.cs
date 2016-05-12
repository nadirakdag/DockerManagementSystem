using DMS.Docker.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using DMS.Core.Models;
using System;
using System.Diagnostics;

namespace DMS.Docker.Implementations
{
    public class Image : IImage
    {
        public List<ImageModel> GetImages(string host, string hostName)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetStringAsync(string.Format("{0}/images/json", host));
                task.Wait();
                string result = task.Result;
                var images =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageModel>>(result);
                images.ForEach(item => item.HostName = hostName);
                return images;
            }
        }

        public string Inspect(string host, string imageName)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetStringAsync(string.Format("{0}/images/{1}/inspect", host, imageName));
                task.Wait();
                return task.Result;
            }
        }

        public void Pull(string host, string imageName)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.PostAsync(string.Format("{0}/images/create?fromImage={1}", host, (imageName + (imageName.Contains(":") ? string.Empty : ":latest"))), new StringContent(string.Empty));
                task.Wait();

                var task2 = task.Result.Content.ReadAsStringAsync();
                task2.Wait();

                string result = task2.Result;
            }
        }

        public List<ImageSearchResult> Search(string host, string term)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetStringAsync(string.Format("{0}/images/search?term={1}", host, term));
                task.Wait();
                string result = task.Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageSearchResult>>(result);
            }
        }
    }
}
