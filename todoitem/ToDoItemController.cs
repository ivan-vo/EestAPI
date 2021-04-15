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
            return Ok(toDoItemService.GetAllTasks());
        }

        [HttpGet("/collection/today")]
        public ActionResult<List<Item>> GetTodayTask()
        {
            return Ok(toDoItemService.GetTodayTask());
        }

        [HttpGet("/dashboard")]
        public ActionResult<DashBoardDTO> GetInfo()
        {
            return Ok(toDoItemService.GetDashboard());
        }

        [HttpGet("/lists/{listId}/tasks/{id}")]
        public ActionResult<List<Item>>  GetToDoItemById(int listId, int id)
        {
            return Ok(toDoItemService.GetById(listId, id));
        }

        [HttpPost("/lists/{listId}/tasks")]
        public ActionResult<IEnumerable<Item>>  CreateToDoItem(int listId,Item item)
        {
            Item createdItem = toDoItemService.CreateToDoItemInList(listId ,item);
            return Created($"/lists/{listId}/tasks/{createdItem.itemId}", createdItem);
        }

        [HttpPost("/lists")]
        public ActionResult<IEnumerable<TaskList>>  CreateToDoItemList(TaskList taskList)
        {
            TaskList createdList = toDoItemService.CreateToDoItemList(taskList);
            return Created($"/lists/{createdList.taskListId}/tasks",createdList);
        }

        [HttpPut("/lists/{listId}/tasks/{id}")]
        public ActionResult<Item> PutToDoItem(int listId,int id, Item item)
        {
            return Ok(toDoItemService.PutItem(listId, id, item));
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