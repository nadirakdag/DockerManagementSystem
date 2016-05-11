namespace DMS.Core.Models
{
    public class ImageModel
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string[] RepoTags { get; set; }
        public object RepoDigests { get; set; }
        public int Created { get; set; }
        public long Size { get; set; }
        public long VirtualSize { get; set; }
        public string HostName { get; set; }
    }
}
