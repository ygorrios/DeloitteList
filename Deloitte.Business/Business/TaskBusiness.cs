using Deloitte.Business.Interface;
using Deloitte.Model;
using Deloitte.Repository.Interface;
using System.Collections.Generic;

namespace Deloitte.Business.Business
{
    public class TaskBusiness : ITaskBusiness
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IUserBusiness _userBusiness;
        public TaskBusiness(
            ITaskRepository taskRepository,
            IUserBusiness userBusiness
            )
        {
            _taskRepository = taskRepository;
            _userBusiness = userBusiness;
        }
        public bool Add(TaskDetailViewModel request)
        {
            return _taskRepository.Add(request);
        }

        public bool Edit(TaskDetailViewModel request)
        {
            return _taskRepository.Edit(request);
        }

        public TaskDetailViewModel GetById(int Id)
        {
            return _taskRepository.GetById(Id);
        }

        public List<TaskDetailViewModel> ListByUser(int UserId)
        {
            var list = _taskRepository.ListByUser(UserId);
            if (list != null && list.Count>0)
            {
                foreach (var item in list)
                {
                    item.User = _userBusiness.GetUserById(item.CreatedBy);
                }
            }
            return list;
        }

        public void Remove(int Id)
        {
            _taskRepository.Remove(Id);
        }
    }
}
