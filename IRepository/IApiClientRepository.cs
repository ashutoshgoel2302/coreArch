using AspCoreModels;
using coreArch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreArch.IRepository
{
    public interface IApiClientRepository
    {
        Task<Message<Child>> SaveUser(Child model);


        Task<List<Child>> GetUsers();

        Task<Child> GetUserById(int id);

        Task<Message<Child>> UpdateUser(Child model);
        Task<Message<Child>> DeleteUser(Child model);
    }
}
