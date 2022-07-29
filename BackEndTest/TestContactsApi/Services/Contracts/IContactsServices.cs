using System.Collections.Generic;
using System.Threading.Tasks;
using TestContactsApi.Models;

namespace TestContactsApi.Services.Contracts
{
    public interface IContactsServices
    {
        Task<Contact> GetContactById(int id);
        void DeleteContactById(int id);

        Task<IEnumerable<Contact>> GetContactByPattern(string pattern);
    }
}
