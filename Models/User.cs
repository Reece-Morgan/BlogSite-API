using System.Text.Json.Serialization;

namespace BlogSite_API.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public string password { get; set; }
    }
}
