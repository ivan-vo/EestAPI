using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using ToDoWebAPI.Models;

namespace ToDoWebAPI.Controllers
{
    [Route("api/ToDoItem")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private ToDoItemService toDoItemService;

        // private ToDoItemService toDoItemService;

        public ToDoItemController(ToDoItemService service)
        {
            this.toDoItemService = service;

        }

        [HttpGet("/lists/{listId}/tasks")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems(int listId)
        {
            return toDoItemService.GetAllTaskByIdList(listId);
        }

        [HttpGet("/lists/{listId}/tasks/{id}")]
        public ActionResult<ToDoItem>  GetToDoItemById(int listId, int id)
        {
            // TODO: Your code here
            return toDoItemService.GetById(listId, id);
        }

        [HttpPost("/lists/{listId}/tasks")]
        public ActionResult<IEnumerable<ToDoItem>>  CreateToDoItem(int listId,ToDoItem toDoItem)
        {
            // TODO: Your code here
            ToDoItem createdItem = toDoItemService.CreateToDoItemInList(listId ,toDoItem);
            return Created($"api/ToDoItem/{createdItem.id}", createdItem);
        }

        [HttpPut("/lists/{listId}/tasks/{id}")]
        public ActionResult<ToDoItem> PutToDoItem(int listId,int id, ToDoItem item)
        {
            return toDoItemService.PutItem(listId, id, item);
        }

        [HttpPatch("/lists/{listId}/tasks/{id}")]
        public ActionResult<ToDoItem> PatchToDoItem(int listId,int id, ToDoItem item)
        {
            return toDoItemService.PutItem(listId, id, item);
        }


        [HttpDelete("/lists/{listId}/tasks/{id}")]
        public void DeleteToDoItemById(int listId, int id)
        {
            // TODO: Your code here
            // await Task.Yield();
            toDoItemService.DeleteItem(listId, id);
        }
    }
}