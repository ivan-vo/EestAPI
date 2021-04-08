using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class ToDoItemContext : DbContext
{
    public DbSet<TaskList> task_lists { get; set; }
    public DbSet<Item> list_items { get; set; }

    public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base (options) {}
}

public class TaskList
{
    public int taskListId { get; set; }
    public string name { get; set; }
    public List<Item> listItems { get; set; }
}

public class Item
{
    public int itemId { get; set; }
    public string title { get; set; }
    public bool done { get; set; }
    public string description { get; set; }
    public DateTime dueDate { get; set; }

    public int taskListId { get; set; }
    public TaskList TaskList { get; set; }
}