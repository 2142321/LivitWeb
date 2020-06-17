using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivitWeb.Models;
using System.Data;
using LivitWeb.Context;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace LivitWeb.Controllers
{
    public class UserTaskController : Controller
    {
        Repository _repository;
        private UserTaskConverter taskConverter;

        public UserTaskController(IConfiguration config)
        {
            _repository = new Repository(new MSSQLTaskContext(config));
            taskConverter = new UserTaskConverter();
        }

        public IActionResult CreateView()
        {
            return View();
        }
       
        public IActionResult Create(CreateViewModel task)
        {
            UserTask userTask = taskConverter.CreateViewToUserTask(task);
            _repository.CreateTask(userTask);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<UserTask> userTasks = _repository.GetAllTasks();
            return View(userTasks);
        }

        public IActionResult EditView(UserTask task)
        {
            EditViewModel viewTask = taskConverter.UserTaskToEditViewModel(task);
            return View(viewTask);
        }

        public IActionResult Edit(EditViewModel task)
        {
            UserTask userTask = taskConverter.EditViewToUserTask(task);
            _repository.UpdateTask(userTask);
            return View("List");
        }
    }
}
