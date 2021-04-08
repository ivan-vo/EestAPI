using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
        public List<Item> GetAllTasks()
        {
            // using (_context)
            // {
                return _context.list_items.ToList();
            // }
        }
        // public void GetDashboard()
        // {
        //     int numTaskToday;
        //     using (_context)
        //     {
        //         numTaskToday = _context.list_items.Where(i => i.dueDate.Date == DateTime.Now.Date).Count();
        //         var allNotDoneTask = _context.list_items
        //             .Where(item => item.done == false)
        //             .GroupBy(item => item.taskListId);
        //     }
        // }
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

        public void CreateToDoItemList(TaskList taskList)
        {
            using (_context)
            {
                _context.task_lists.Add(taskList);
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
        public Item PutItem(int idList, int id, Item item)
        {
            item.taskListId = idList;
            item.itemId = id;
            _context.list_items.Update(item);
            _context.SaveChanges();
            return item;
        }
        public Item PatchItem(int idList,int id, Item item)
        {
            using (_context)
            {
            item.taskListId = idList;
            item.itemId = id;
            _context.list_items.Update(item);
            _context.SaveChanges();
            return item;
            }
        }

        public void DeleteItem(int idList, int id)
        {
            using (_context)
            {
                Item item = new Item(){itemId = id, taskListId = idList};
                _context.list_items.Remove(item);
                _context.SaveChanges();
            }
        }

        public void DeleteTaskList(int idList)
        {
            using (_context)
            {
                TaskList taskList = new TaskList(){ taskListId = idList};
                _context.task_lists.Remove(taskList);
                _context.SaveChanges();
            }
        }
    }
}