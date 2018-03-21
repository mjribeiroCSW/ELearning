using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectXCore.Data;
using ProjectXCore.Models;
using ProjectXCore.Repository;

namespace ProjectXCore.Controllers
{
    [Route("api/[controller]")]
    public class WorkersController : Controller
    {
        private IRepository<Workers> repoWorker;
        public WorkersController(IRepository<Workers> repoWorker)
        {
            this.repoWorker = repoWorker;
        }

        // GET api/workers
        [HttpGet(Name = "Get Workers table")]
        public IActionResult GetWorkers()
        {
            return Ok(repoWorker.GetAll());
        }

        // GET api/workers/{id}
        [HttpGet("{id}", Name = "GetWorker")]
        public IActionResult GetById(int id)
        {
            var worker = repoWorker.Get(id);
            if (worker == null)
            {
                //404
                return NotFound();
            }
            //return cod 200
            return Ok(worker);
        }

        // POST api/Workers
        [HttpPost(Name = "Post Worker")]
        public IActionResult PostWorkers([FromBody] Workers Worker)
        {
            //checks if the model received from POST is equal to Model class Workers         
            if (!ModelState.IsValid)
            {
                //400
                return BadRequest(ModelState);
            }

            //checks if theres already an login inside the database or email
            var listT = repoWorker.GetAll();
            if ((listT.Any(t => t.Login == Worker.Login)) || (listT.Any(t => t.Email == Worker.Email)))
            {
                // It's a duplicate.  Return an HTTP 409 Conflict error 
                return StatusCode(409, Json("its a duplicate"));
                //return StatusCode(409);
            }
            repoWorker.Insert(Worker);
            //return code 201
            return CreatedAtRoute("GetWorker", new { id = Worker.Id }, Worker);
        }

        // PUT api/Workers/{id}
        [HttpPut("{id}")]
        public IActionResult PutWorkers(int id, [FromBody] Workers worker)
        {
            if (!ModelState.IsValid)
            {
                //return 400
                return BadRequest(ModelState);
            }

            var item = repoWorker.Get(id);
            if(item == null)
            {
                //return 404
                return NotFound();
            }
            ////searches in the list of workers if theres someone already with that login or email
            //if ((_context.Workers.Any(t => t.Login == worker.Login)) || (_context.Workers.Any(t => t.Email == worker.Email)))
            //{
            //    // It's a duplicate.  Return an HTTP 409 Conflict error 
            //    //return StatusCode(409, Json("its a duplicate"));
            //    return StatusCode(409);
            //}

            item.Name = worker.Name;
            item.Login = worker.Login;
            item.Email = worker.Email;
            item.Phone = worker.Phone;
            item.Details = worker.Details;

            repoWorker.Update(item);

            //return 204
            return new NoContentResult();
        }

        // DELETE api/Workers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWorker(int id)
        {
            var Client = repoWorker.Get(id);

            if (Client == null)
            {
                //return 404
                return NotFound();
            }
            repoWorker.Delete(Client);
            //return 204
            return new NoContentResult();
        }
    }
}
