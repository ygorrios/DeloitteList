using Deloitte.Model;
using System.Collections.Generic;

namespace Deloitte.Repository.Interface
{
    public interface ITaskRepository
    {
        List<TaskDetailViewModel> ListByUser(int UserId);
        TaskDetailViewModel GetById(int Id);
        void Remove(int Id);
        bool Add(TaskDetailViewModel request);
        bool Edit(TaskDetailViewModel request);
    }
}
