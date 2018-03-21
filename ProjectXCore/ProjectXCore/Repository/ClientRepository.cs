using Microsoft.EntityFrameworkCore;
using ProjectXCore.Data;
using ProjectXCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ProjectContext context;

        public ClientRepository(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        public Client GetId(int id)
        {
            return context.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
}
