using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebAPI.Controllers
{
    [Route("api/ToDoItem")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private ToDoItemService toDoItemService;

        public ToDoItemController(ToDoItemService service)
        {
            this.toDoItemService = service;

        }

        [HttpGet("/tasks")]
        public ActionResult<IEnumerable<Item>> GetAllToDoItems()
        {
            return toDoItemService.GetAllTasks();
        }

        [HttpGet("/collection/today")]
        public ActionResult<object> GetTodayTask()
        {
            return Ok(toDoItemService.GetTodayTask());
        }

        [HttpGet("/dashboard")]
        public ActionResult<DashBoard> GetInfo()
        {
            toDoItemService.GetDashboard();
            return null;
        }

        [HttpGet("/lists/{listId}/tasks/{id}")]
        public ActionResult<List<Item>>  GetToDoItemById(int listId, int id)
        {
            return toDoItemService.GetById(listId, id);
        }

        [HttpPost("/lists/{listId}/tasks")]
        public ActionResult<IEnumerable<Item>>  CreateToDoItem(int listId,Item item)
        {
            Item createdItem = toDoItemService.CreateToDoItemInList(listId ,item);
            return Created($"api/ToDoItem/{createdItem.itemId}", createdItem);
        }

        [HttpPost("/createlist")]
        public void  CreateToDoItemList(TaskList taskList)
        {
            toDoItemService.CreateToDoItemList(taskList);
        }

        [HttpPatch("/lists/{listId}/tasks/{id}")]
        public ActionResult<Item> PatchToDoItem(int listId,int id, Item item)
        {
            return toDoItemService.PatchItem(listId, id, item);
        }

        [HttpPut("/lists/{listId}/tasks/{id}")]
        public ActionResult<Item> PutToDoItem(int listId,int id, Item item)
        {
            return toDoItemService.PutItem(listId, id, item);
        }


        [HttpDelete("/lists/{listId}/tasks/{id}")]
        public void DeleteToDoItemById(int listId, int id)
        {
            toDoItemService.DeleteItem(listId, id);
        }

        [HttpDelete("/{listId}")]
        public void DeleteTaskList(int listId)
        {
            toDoItemService.DeleteTaskList(listId);
        }
    }
}