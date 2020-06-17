using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivitWeb.Models;
using System.Threading;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Security.Claims;

namespace LivitWeb.Context
{
    public class MSSQLTaskContext : IRepository
    {
        private readonly string _connectionString;
        public MSSQLTaskContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("LivitDbConnection");
        }

        public void CreateTask(UserTask task)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO UserTask (title, description, date, location, isgroup, isdone, userid) VALUES (@title, @description, @date, @location, @isgroup, @isdone, 1)", connection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@title", task.Title);
                    sqlCommand.Parameters.AddWithValue("@description", task.Description);
                    sqlCommand.Parameters.AddWithValue("@date", task.Date);
                    sqlCommand.Parameters.AddWithValue("@location", task.Location);
                    sqlCommand.Parameters.AddWithValue("@isgroup", task.isGroup);
                    sqlCommand.Parameters.AddWithValue("@isdone", task.isDone);
                    task.Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                  //sqlCommand.Parameters.AddWithValue("@userid", user.getId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<UserTask> GetAllTasks()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    List<UserTask> userTasks = new List<UserTask>();
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM UserTask", connection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {   
                        UserTask task = new UserTask();
                        task.Id = reader.GetInt32("id");
                        task.Title = reader.GetString("title");
                        task.Description = reader.GetString("description");
                        task.Date = reader.GetString("date");
                        task.Location = reader.GetString("location");
                        task.isGroup = reader.GetBoolean("isgroup");
                        task.isDone = reader.GetBoolean("isdone");
                        
                        userTasks.Add(task);
                    }
                    return userTasks;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTask(UserTask task)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("UPDATE UserTask set title = @title, description = @description, date = @date, location = @location, isgroup = @isgroup, isdone = @isdone WHERE id = @id", connection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@title", task.Title);
                    sqlCommand.Parameters.AddWithValue("@description", task.Description);
                    sqlCommand.Parameters.AddWithValue("@date", task.Date);
                    sqlCommand.Parameters.AddWithValue("@location", task.Location);
                    sqlCommand.Parameters.AddWithValue("@isgroup", task.isGroup);
                    sqlCommand.Parameters.AddWithValue("@isdone", task.isDone);
                    sqlCommand.Parameters.AddWithValue("@id", task.Id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
