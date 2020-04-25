﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GitMeet.Models;

namespace GitMeet.Data
{
    public class UsersManager
    {
        IRestService _restService;

        public UsersManager(IRestService service)
        {
            _restService = service;
        }

        public Task<List<User>> GetUsersAsync(string location, string language)
        {
            return _restService.GetDataAsync(location, language);
        }

        public Task<UserInfo> GetUserAsync(string username)
        {
            return _restService.GetUserInfoAsync(username);
        }
    }
}
