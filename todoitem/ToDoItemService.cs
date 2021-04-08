using System.Collections.Generic;
using System.Linq;

namespace ToDoWebAPI
{
    public class ToDoItemService
    {
        private ToDoItemContext _context;
        public ToDoItemService(ToDoItemContext context)
        {
            this._context = context;
        }
        public List<Item> GetAllTaskByIdList(int idList)
        {
            using (_context)
            {
                return _context.list_items.Where(items => items.taskListId == idList).ToList();
            }
        }
        public Item CreateToDoItemInList(int idList, Item item)
        {
            using (_context)
            {
                item.taskListId = idList;
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
        }
        public void CreateToDoItemList(int idList)
        {
            using (_context)
            {
                _context.task_lists.Add(new TaskList(){taskListId = idList});
                _context.SaveChanges();
            }
        }
        public List<Item> GetById(int idList, int id)
        {
            using (_context)
            {
                var items =  GetAllTaskByIdList(idList);
                var item = items.Where(item => item.itemId == id).ToList();
                return item;
            }
        }
        // public ToDoItem PutItem(int listId, int id, ToDoItem toDoItem)
        // {
        //     tasksList[listId].Insert(id, toDoItem);
        //     tasksList[listId][id].id = tasksList[listId][id + 1].id;
        //     tasksList[listId].RemoveAt(id + 1);
        //     return tasksList[listId][id];
        // }
        // public ToDoItem PatchItem(int listId,int id, ToDoItem toDoItem)
        // {
        //     if(toDoItem.doDate != null)
        //     {
        //         tasksList[listId][id].doDate = toDoItem.doDate;
        //     }
        //     else if(toDoItem.id != 0)
        //     {
        //         tasksList[listId][id].id = toDoItem.id;
        //     }
        //     else if(toDoItem.title != null)
        //     {
        //         tasksList[listId][id].title = toDoItem.title;
        //     }
        //     tasksList[listId][id].done = toDoItem.done;
        //     return tasksList[listId][id];
        // }

        public void DeleteItem(int idList, int id)
        {
            using (_context)
            {
                Item item = new Item(){itemId = id, taskListId = idList};
                _context.list_items.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}