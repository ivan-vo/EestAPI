using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
//using ToDoWebAPI.Models;

namespace ToDoWebAPI.Controllers
{
    [Route("api/ToDoItemsList")]
    [ApiController]

    public class ToDoItemsListController : ControllerBase
    {
        private ToDoItemService toDoItemService;

        public ToDoItemsListController(ToDoItemService service)
        {
            this.toDoItemService = service;
        }
        [HttpGet("/lists")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems()
        {
            int listId = Int32.Parse(this.Request.Query["listId"]);
            return Ok(toDoItemService.GetAllTaskByIdList(listId));
        }

        [HttpGet("/itembyid")]
        public ActionResult<List<Item>> GetToDoItemById()
        {
            // TODO: Your code here
            int listId = Int32.Parse(this.Request.Query["listId"]);
            int id = Int32.Parse(this.Request.Query["id"]);
            return toDoItemService.GetById(listId, id);
        }
    }
}