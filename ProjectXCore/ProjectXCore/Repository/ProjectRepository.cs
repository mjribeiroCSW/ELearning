using Microsoft.EntityFrameworkCore;
using ProjectXCore.Data;
using ProjectXCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Repository
{

    // implementação de Repository e Interface

    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ProjectContext context;
       

        public ProjectRepository(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        //get
        public ProjectDTOAll GetPro(int id)
        {

            var item =  context.Projects
                .Include(x => x.Client)
                .FirstOrDefault(x => x.Id == id);
            var itemA = new ProjectDTOAll();

            itemA.BeginDate = item.BeginDate;
            itemA.EndDate = item.EndDate;
            itemA.Details = item.Details;
            itemA.Client = item.Client;
            itemA.Name = item.Name;
            itemA.ProjectCode = item.ProjectCode;

            itemA.WorkersList = context.ProjectWorkers
                .Where(x => x.ProjectId == id)
                .Select(x => x.Worker)
                .ToList();

            return itemA;
    
        }


        //get all
        public ICollection<Project> GetAll()
        {
            return context.Projects
                .Include(x => x.Client)  
                .ToList();
        }

        //vai buscar todos os projects de 1 cliente
        public ICollection<Project> GetAllFromClient(int id)
        {
            return context.Projects
                .Where(x => x.Client.Id == id)
                .ToList();
        }

        public void Update(Project project, Workers worker)
        {
            var New = new ProjectWorkers();
            New.ProjectId = project.Id;
            New.WorkerId = worker.Id;
            New.Worker = worker;
            New.Project = project;
            context.ProjectWorkers.Add(New);
            context.SaveChanges();
        }
    }
}
