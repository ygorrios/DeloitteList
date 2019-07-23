using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Model
{
    public class TaskDetailViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public int CreatedBy { get; set; }
        public UserViewModel User { get; set; }
        public List<TaskHistoryViewModel> TaskHistories { get; set; }
    }
}
