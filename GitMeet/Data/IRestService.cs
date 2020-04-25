using System.Collections.Generic;
using System.Threading.Tasks;
using GitMeet.Models;

namespace GitMeet.Data
{
    public interface IRestService
    {
        Task<List<User>> GetDataAsync(string location, string language);
        Task<UserInfo> GetUserInfoAsync(string username);
    }
}
