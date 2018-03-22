using ProjectXCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Repository
{
    public interface IProjectRepository : IRepository <Project>
    {
        ICollection<Project> GetAll();
        ICollection<Project> GetAllFromClient(int id);
        ProjectDTOAll GetPro(int id);
        void Update(Project project, Workers worker);
    }
}
