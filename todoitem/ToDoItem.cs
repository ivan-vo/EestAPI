using System;
using System.Collections.Generic;

namespace ToDoWebAPI
{
    public class ToDoItem
    {
        public DateTime? doDate { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool done { get; set; }
    }
}