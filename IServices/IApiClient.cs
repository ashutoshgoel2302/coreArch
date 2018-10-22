using AspCoreModels;
using coreArch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace coreArch.Services
{
    public interface IApiClient
    {

        Task<T> GetAsync<T>(Uri requestUrl);
        Task<Message<T>> DeleteAsync<T>(Uri requestUrl);
        Task<Message<T>> PostAsync<T>(Uri requestUrl, T content);

        Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content);

        Task<Message<T>> PutAsync<T>(Uri requestUrl, T content);
        Uri CreateRequestUri(string relativePath, string queryString = "");


        HttpContent CreateHttpContent<T>(T content);


        void addHeaders();

        Task<List<Child>> GetUsers();

        Task<Child> GetByIdUsers(int id);
        Task<Message<Child>> SaveUser(Child model);

        Task<Message<Child>> UpdateUser(Child model);
        Task<Message<Child>> DeleteUser(Child model);
    }
}
