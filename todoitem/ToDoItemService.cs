using System.Collections.Generic;
using System.Linq;

namespace ToDoWebAPI
{
    public class ToDoItemService
    {
        public List<List<ToDoItem>> tasksList = new List<List<ToDoItem>>
        {
            new List<ToDoItem>
            {
                new ToDoItem(){title = "Abra"}
            }
        };
        private int lastId = 1;
        public List<ToDoItem> GetAllTaskByIdList(int id)
        {
            return tasksList[id];
        }
        public ToDoItem CreateToDoItemInList(int id, ToDoItem item)
        {
            item.id = lastId++;
            if (tasksList[id] == null)
            {
                tasksList.Add(new List<ToDoItem>());
            }
            tasksList[id].Add(item);
            return item;
        }
        public ToDoItem GetById(int idList, int id)
        {
            return tasksList[idList][id];
        }
        public ToDoItem PutItem(int listId, int id, ToDoItem toDoItem)
        {
            tasksList[listId].Insert(id, toDoItem);
            tasksList[listId][id].id = tasksList[listId][id + 1].id;
            tasksList[listId].RemoveAt(id + 1);
            return tasksList[listId][id];
        }
        public ToDoItem PatchItem(int listId,int id, ToDoItem toDoItem)
        {
            if(toDoItem.doDate != null)
            {
                tasksList[listId][id].doDate = toDoItem.doDate;
            }
            else if(toDoItem.id != 0)
            {
                tasksList[listId][id].id = toDoItem.id;
            }
            else if(toDoItem.title != null)
            {
                tasksList[listId][id].title = toDoItem.title;
            }
            tasksList[listId][id].done = toDoItem.done;
            return tasksList[listId][id];
        }

        public void DeleteItem(int listId, int id)
        {
            tasksList[listId].RemoveAt(id);
        }
    }
}