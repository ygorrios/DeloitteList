using Deloitte.Model;
using Deloitte.Repository.Context.Deloitte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Business.Interface
{
    public interface ITaskBusiness
    {
        List<TaskDetailViewModel> ListByUser(int UserId);
        TaskDetailViewModel GetById(int Id);
        void Remove(int Id);
        bool Add(TaskDetailViewModel request);
        bool Edit(TaskDetailViewModel request);
    }
}
