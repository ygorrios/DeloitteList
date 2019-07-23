using Deloitte.Model;
using Deloitte.Repository.Context.Deloitte;
using Deloitte.Repository.Context.Deloitte.Models;
using Deloitte.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deloitte.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public bool Add(TaskDetailViewModel request)
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
              .UseInMemoryDatabase(databaseName: "TaskDetail")
              .Options;

            using (var context = new DeloitteContext(options))
            {
                request.Id = GetLastTaskDetailId();
                context.TaskDetail.Add(new TaskDetail
                {
                    Id = request.Id,
                    Checked = request.Checked,
                    Description = request.Description,
                    CreatedBy = request.CreatedBy
                });
                var task = context.SaveChanges();

                return AddHistory(request);
            }
        }

        public bool Edit(TaskDetailViewModel request)
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
              .UseInMemoryDatabase(databaseName: "TaskDetail")
              .Options;

            using (var context = new DeloitteContext(options))
            {
                var edit = context.TaskDetail.Where(w => w.Id == request.Id).FirstOrDefault();
                if (edit != null)
                {
                    edit.Description = request.Description;
                    edit.Checked = request.Checked;
                    var task = context.SaveChanges();

                    return AddHistory(request);
                }
                return false;
            }
        }

        public bool AddHistory(TaskDetailViewModel request)
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
              .UseInMemoryDatabase(databaseName: "TaskHistory")
              .Options;

            using (var context = new DeloitteContext(options))
            {
                context.TaskHistory.Add(new TaskHistory
                {
                    Id = GetLastTaskHistoryId(),
                    TaskDetailId = request.Id,
                    UpdateTime = DateTime.Now
                });
                return context.SaveChanges() > 0;
            }
        }

        private int GetLastTaskDetailId()
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
              .UseInMemoryDatabase(databaseName: "TaskDetail")
              .Options;

            int id = 1;
            using (var context = new DeloitteContext(options))
            {
                var query = context.TaskDetail.OrderByDescending(o => o.Id).FirstOrDefault();
                if (query != null)
                {
                    id = query.Id + 1;
                }
                return id;
            }
        }

        private int GetLastTaskHistoryId()
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
              .UseInMemoryDatabase(databaseName: "TaskHistory")
              .Options;

            int id = 1;
            using (var context = new DeloitteContext(options))
            {
                var query = context.TaskHistory.OrderByDescending(o => o.Id).FirstOrDefault();
                if (query != null)
                {
                    id = query.Id + 1;
                }
                return id;
            }
        }



        public TaskDetailViewModel GetById(int Id)
        {
            TaskDetailViewModel result = null;

            var options = new DbContextOptionsBuilder<DeloitteContext>()
             .UseInMemoryDatabase(databaseName: "TaskDetail")
             .Options;

            using (var context = new DeloitteContext(options))
            {
                result = (from i in context.TaskDetail
                          where i.Id == Id
                          select new TaskDetailViewModel
                          {
                              Checked = i.Checked,
                              Description = i.Description,
                              CreatedBy = i.CreatedBy,
                              Id = i.Id,

                          }).FirstOrDefault();
            }

            options = new DbContextOptionsBuilder<DeloitteContext>()
             .UseInMemoryDatabase(databaseName: "TaskHistory")
             .Options;

            if (result != null)
            {
                using (var context = new DeloitteContext(options))
                {
                    result.TaskHistories = (from i in context.TaskHistory
                                            where i.TaskDetailId == result.Id
                                            select new TaskHistoryViewModel
                                            {
                                                UpdateTime = i.UpdateTime,
                                                TaskDetailId = i.TaskDetailId,
                                                Id = i.Id
                                            }).OrderByDescending(o => o.UpdateTime).ToList();
                }
            }

            return result;
        }

        public List<TaskDetailViewModel> ListByUser(int UserId)
        {
            List<TaskDetailViewModel> result = null;

            var options = new DbContextOptionsBuilder<DeloitteContext>()
             .UseInMemoryDatabase(databaseName: "TaskDetail")
             .Options;

            using (var context = new DeloitteContext(options))
            {
                result = (from i in context.TaskDetail
                          where i.CreatedBy == UserId
                          select new TaskDetailViewModel
                          {
                              Checked = i.Checked,
                              Description = i.Description,
                              CreatedBy = i.CreatedBy,
                              Id = i.Id,

                          }).ToList();
            }

            if (result != null && result.Count > 0)
            {
                options = new DbContextOptionsBuilder<DeloitteContext>()
                  .UseInMemoryDatabase(databaseName: "TaskHistory")
                  .Options;

                foreach (var item in result)
                {


                    using (var context = new DeloitteContext(options))
                    {
                        item.TaskHistories = (from i in context.TaskHistory
                                              where i.TaskDetailId == item.Id
                                              select new TaskHistoryViewModel
                                              {
                                                  UpdateTime = i.UpdateTime,
                                                  TaskDetailId = i.TaskDetailId,
                                                  Id = i.Id
                                              }).OrderByDescending(o => o.UpdateTime).ToList();
                    }
                }
            }

            return result;
        }

        public void Remove(int Id)
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
            .UseInMemoryDatabase(databaseName: "TaskHistory")
            .Options;

            using (var context = new DeloitteContext(options))
            {
                var remove = context.TaskHistory.Where(w => w.TaskDetailId == Id).ToList();
                if (remove != null && remove.Count > 0)
                {
                    context.RemoveRange(remove);
                    context.SaveChanges();
                }
            }

            options = new DbContextOptionsBuilder<DeloitteContext>()
             .UseInMemoryDatabase(databaseName: "TaskDetail")
             .Options;

            using (var context = new DeloitteContext(options))
            {
                var remove = context.TaskDetail.Where(w => w.Id == Id).FirstOrDefault();
                if (remove != null)
                {
                    context.Remove(remove);
                    context.SaveChanges();
                }
            }
        }
    }
}
