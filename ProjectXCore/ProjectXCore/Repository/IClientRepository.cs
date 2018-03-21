using ProjectXCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Repository
{
    public interface IClientRepository : IRepository <Client>
    {
        Client GetId(int id);
    }
}
