using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivitWeb.Models
{
    public class UserTaskConverter
    {
        public UserTaskConverter()
        {

        }
        public UserTask CreateViewToUserTask(CreateViewModel viewTask)
        {
            UserTask task = new UserTask();
            task.Title = viewTask.Title;
            task.Description = viewTask.Descrition;
            task.Date = viewTask.Date;
            task.Location = viewTask.Location;
            task.isGroup = viewTask.isGroup;
            return task;
        }

        public EditViewModel UserTaskToEditViewModel(UserTask task)
        {
            EditViewModel viewTask = new EditViewModel();
            viewTask.Title = task.Title;
            viewTask.Descrition = task.Description;
            viewTask.Date = task.Date;
            viewTask.Location = task.Location;
            viewTask.isGroup = task.isGroup;
            viewTask.isDone = task.isDone;
            viewTask.Id = task.Id;
            return viewTask;
        }

        public UserTask EditViewToUserTask(EditViewModel viewTask)
        {
            UserTask task = new UserTask();
            task.Title = viewTask.Title;
            task.Description = viewTask.Descrition;
            task.Date = viewTask.Date;
            task.Location = viewTask.Location;
            task.isGroup = viewTask.isGroup;
            task.isDone = viewTask.isDone;
            task.Id = viewTask.Id;
            return task;
        }
    }
}
