namespace DMS.Core.Models
{
    public class ImageSearchResult
    {
        public int star_count { get; set; }
        public bool is_official { get; set; }
        public string name { get; set; }
        public bool is_trusted { get; set; }
        public bool is_automated { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} \t {1}", is_official, name);
        }
    }
}
