using DMS.Core.Models;
using DMS.Docker.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System;

namespace DMS.Docker.Implementations
{
    public class Container : IContainer
    {
        public List<ContainerModel> GetContainers(string host, string hostName, int hostId, int take = 5)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetStringAsync(string.Format("{0}/containers/json?limit={1}", host, take));
                task.Wait();
                string result = task.Result;
                var containerList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContainerModel>>(result);
                containerList.ForEach(item => { item.HostName = hostName; item.HostId = hostId; });
                return containerList;
            }
        }

        public void RemoveContainer(string host, string containerId)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.DeleteAsync(string.Format("{0}/containers/{1}", host, containerId));
                task.Wait();

                var task2 = task.Result.Content.ReadAsStringAsync();
                task2.Wait();

                string result = task2.Result;
            }
        }

        public void RestartContainer(string host, string containerId)
        {
            SendOperationalReq(host, containerId, "restart");
        }

        public void StartContainer(string host, string containerId)
        {
            SendOperationalReq(host, containerId, "start");
        }

        public void StopContainer(string host, string containerId)
        {
            SendOperationalReq(host, containerId, "stop");
        }

        private void SendOperationalReq(string host, string containerId, string op)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.PostAsync(string.Format("{0}/containers/{1}/{2}", host, containerId.Replace("/", string.Empty), op), new StringContent(""));
                task.Wait();

                var task2 = task.Result.Content.ReadAsStringAsync();
                task2.Wait();

                string result = task2.Result;
            }
        }
    }
}
