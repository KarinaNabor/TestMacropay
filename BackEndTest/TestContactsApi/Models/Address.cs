using System.Text.Json.Serialization;

namespace TestContactsApi.Models
{
    public class Address
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string AddressName { get; set; }
        [JsonIgnore]
        public int ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }
    }
}
