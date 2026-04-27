using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Tracker
{
    public class TaskItem
    {
        public int TaskID {  get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        
    }
}
