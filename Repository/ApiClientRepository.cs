using AspCoreModels;
using coreArch.IRepository;
using coreArch.Models;
using coreArch.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreArch.Repository
{
    public class ApiClientRepository: IApiClientRepository
    {
        private readonly IApiClient _apiClient;
        private ILogger<ApiClientRepository> _logger;
        public ApiClientRepository(IApiClient apiClient,          
           ILogger<ApiClientRepository> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }
       
        public async Task<Message<Child>> SaveUser(Child model)
        {

            var response = await _apiClient.SaveUser(model);
            return response;
        }
        public async Task<List<Child>> GetUsers()
        {

            var childList = await _apiClient.GetUsers();
            return childList;
        }
        public async Task<Child> GetUserById(int id)
        {

            var child = await _apiClient.GetByIdUsers(id);
            return child;
        }
        public async Task<Message<Child>> UpdateUser(Child model)
        {
            var response = await _apiClient.UpdateUser(model);
            return response;
        }
        public async Task<Message<Child>> DeleteUser(Child model)
        {
            var response = await _apiClient.DeleteUser(model);
            return response;
        }
    }
}
