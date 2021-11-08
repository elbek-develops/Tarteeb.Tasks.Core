using Dapper;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.Tasks.Core.Data;

namespace Tarteeb.Tasks.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : RESTFulController
    {
        private readonly IDbConnectionFactory factory;

        public TasksController(IDbConnectionFactory factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            using (var connection = factory.GetConnection())
            {

                connection.Open();
                var data = await connection.GetListAsync<Model.Task>();
                connection.Close();
                return Ok(data.ToList());
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            using (var connection = factory.GetConnection())
            {

                connection.Open();
                var data = await connection.GetAsync<Model.Task>(id);
                connection.Close();
                if (data is null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Model.Task task)
        {
            using (var connection = factory.GetConnection())
            {

                connection.Open();
                int? newId = await connection.InsertAsync(task);
                connection.Close();

                if (!newId.HasValue)
                {
                    return Problem("Unable to create task record.");
                }
                return Created(newId);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var connection = factory.GetConnection())
            {
                connection.Open();
                var task = await connection.GetAsync<Model.Task>(id);
                if (task is null)
                {
                    return NotFound();
                }
                int affectedRows = await connection.DeleteAsync(task);
                connection.Close();

                if (affectedRows == 0)
                {
                    return Problem("Unable to delete task record.");
                }
                return Ok(affectedRows);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Model.Task task)
        {
            using (var connection = factory.GetConnection())
            {
                connection.Open();
                int affectedRows = await connection.UpdateAsync(task);
                connection.Close();

                if (affectedRows == 0)
                {
                    return Problem("Unable to update task record.");
                }
                return Ok(affectedRows);
            }

        }
    }
}
