using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivitWeb.Models
{
    public class UserTask
    {
        public UserTask()
        {

        }

        public UserTask(string title, string description, string date, string location, bool isgroup)
        {
            this.Title = title;
            this.Date = date;
            this.isGroup = isgroup;
            this.isDone = false;
            this.Description = description;
            this.Location = location;
        }

        public UserTask(string title, string description, string date, string location, bool isgroup, bool isDone)
        {
            this.Title = title;
            this.Date = date;
            this.isGroup = isgroup;
            this.isDone = isDone;
            this.Description = description;
            this.Location = location;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public bool isGroup { get; set; }
        public bool isDone { get; set; }
        public int UserId { get; set; }
    }
}
