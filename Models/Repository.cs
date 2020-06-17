using LivitWeb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LivitWeb.Models
{
    public class Repository : IRepository
    {
        //UserTaskContext taskContext;
        //  List<UserTask> tasks;
        IRepository rep;

        public Repository(IRepository rep)
        {
            // taskContext = new UserTaskContext(config);
            this.rep = rep;
        }

   
        public List<UserTask> GetAllTasks()
        {
            return rep.GetAllTasks();
           // return tasks;
        }

        public void CreateTask(UserTask task)
        {
            rep.CreateTask(task);
        }

        public void UpdateTask(UserTask task)
        {
            rep.UpdateTask(task);
        }
    }
}
