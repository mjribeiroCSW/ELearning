using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectXCore.Data;
using ProjectXCore.Models;
using ProjectXCore.Repository;

namespace ProjectXCore.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectRepository repoProject;
        private IClientRepository repoClient;
        public ProjectsController(IProjectRepository repoProject, IClientRepository repoClient)
        {
            this.repoProject = repoProject;
            this.repoClient = repoClient;
        }

        // GET: api/projects
        [HttpGet(Name = "Get Projects table")]
        public IActionResult GetProjects()
        {
            // check this code to make it work with both list of workers
            return Ok(repoProject.GetAll().ToList());
        }

        // GET: api/projects/{id}
        [HttpGet("{id}", Name = "Get Projects")]
        public IActionResult GetById(int id)
        {
            var Project = repoProject.GetPro(id);
            if (Project == null)
            {
                //404
                return NotFound();
            }
            //return cod 200
            return Ok(Project);
        }

        // POST: api/projects
        [HttpPost(Name = "Post Project")]
        public IActionResult PostProject([FromBody] ProjectDTOClient ProjectPOST)
        {
            //checks if the model received from POST is equal to Model class Project       
            if (!ModelState.IsValid)
            {
                //400
                return BadRequest(ModelState);
            }
            var Client = repoClient.Get(ProjectPOST.Client);
            if (Client == null)
            {
                return NotFound("Invalid Client");
            }
            // rever esta linha
            //ModelState.AddModelError(nameof(Project.Name), "Teste Erro");
            var ProjectToAdd = new Project();
            ProjectToAdd.Client = Client;
            ProjectToAdd.BeginDate = ProjectPOST.BeginDate;
            ProjectToAdd.Details = ProjectPOST.Details;
            ProjectToAdd.EndDate = ProjectPOST.EndDate;
            ProjectToAdd.Name = ProjectPOST.Name;
            ProjectToAdd.ProjectCode = ProjectPOST.ProjectCode;
            repoProject.Insert(ProjectToAdd);
            //return code 201
            return CreatedAtRoute("Get Projects", new { id = ProjectToAdd.Id }, ProjectToAdd);
        }

        // POST: /projects/{id}/Workers/{id2}
        [HttpPost("{id}/workers/{id2}",Name = "Post Worker on Project")]
        public IActionResult PostWorkerOnProject([FromRoute] int id, [FromRoute] int id2)
        {
            return Ok("Added Worker {id2} to project {id} ");
        }


        // PUT: Project_X/Projects/{id}
        [HttpPut("{id}")]
        public IActionResult PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                //return 400
                return BadRequest(ModelState);
            }
            var item = repoProject.Get(id);
            if (item == null)
            {
                //return 404
                return NotFound();
            }
            item.ProjectCode = project.ProjectCode;
            item.Name = project.Name;
            item.BeginDate = project.BeginDate;
            item.EndDate = project.EndDate;
            item.Details = project.Details;
            repoProject.Update(item);
            //return 204
            return new NoContentResult();
        }

        // DELETE: Project_X/Projects/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var Project = repoProject.Get(id);

            if (Project == null)
            {
                //return 404
                return NotFound();
            }

            repoProject.Delete(Project);
            //return 204
            return new NoContentResult();
        }
    }
}