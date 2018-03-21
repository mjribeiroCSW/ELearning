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
    public class ClientsController : Controller
    {
        private IClientRepository repoClient;
        private IProjectRepository repoProject;
        public ClientsController(IClientRepository repoClient, IProjectRepository repoProject)
        {
            this.repoClient = repoClient;
            this.repoProject = repoProject;
        }

        //private readonly ProjectContext Database;
        ////construtor
        //public ClientsController(ProjectContext context)
        //{
        //    Database = context;
        //}

        // GET: api/Clients
        [HttpGet(Name = "Get Clients table")]
        public IActionResult GetClients()
        {
            return Ok(repoClient.GetAll());
        }

        // GET: api/Clients/{id}
        [HttpGet("{id}", Name = "Get Client")]
        public IActionResult GetById(int id)
        {
            var Client = repoClient.Get(id);
            if (Client == null)
            {
                //404
                return NotFound();
            }
            //receives list of projects of client ID
            var Projects = repoProject.GetAllFromClient(id);
            //iterates all fields to create a smaller list
            ICollection<ProjectDTO> ProjectDTO = new List<ProjectDTO>();
            foreach(var Item in Projects)
            {
                var ItemProject = new ProjectDTO();           
                ItemProject.Details = Item.Details;
                ItemProject.Name = Item.Name;
                ItemProject.ProjectCode = Item.ProjectCode;
                ProjectDTO.Add(ItemProject);
            }

            var ClientDTO = new ClientDTO();
            ClientDTO.Email = Client.Email;
            ClientDTO.Name = Client.Name;
            ClientDTO.ListProjects = ProjectDTO;
            //return cod 200
            return Ok(ClientDTO);
        }

        // POST: api/Clients
        [HttpPost (Name = "Post Client")]
        public IActionResult PostClient([FromBody] Client Client)
        {
            //checks if the model received from POST is equal to Model class Workers         
            if (!ModelState.IsValid)
            {
                //400
                return BadRequest(ModelState);
            }
            repoClient.Insert(Client);
            //return code 201
            return CreatedAtRoute("Get Client", new { id = Client.Id }, Client);
        }

        // PUT: api/Clients/{id}
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, [FromBody] Client Client)
        {
            if (!ModelState.IsValid)
            {
                //return 400
                return BadRequest(ModelState);
            }

            var item = repoClient.Get(id);
            if (item == null)
            {
                //return 404
                return NotFound();
            }

            item = Client;

            item.Email = Client.Email;
            item.Name = Client.Name;
            item.OwnerName = Client.OwnerName;
            repoClient.Update(item);

            //return 204
            return new NoContentResult();
        }

        // DELETE: Project_X/Clients/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var Client = repoClient.Get(id);

            if (Client == null)
            {
                //return 404
                return NotFound();
            }

            repoClient.Delete(Client);
            //return 204
            return new NoContentResult();
        }
    }
}