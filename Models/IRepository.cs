using LivitWeb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivitWeb.Models
{
    public interface IRepository
    {
        public List<UserTask> GetAllTasks();

        public void CreateTask(UserTask task);

        public void UpdateTask(UserTask task);
        
    }
}
