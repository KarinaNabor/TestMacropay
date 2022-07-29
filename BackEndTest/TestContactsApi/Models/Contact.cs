using System.Collections.Generic;

namespace TestContactsApi.Models
{
    public class Contact
    {
        public Contact()
        {
            Addresses = new HashSet<Address>();
        }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
