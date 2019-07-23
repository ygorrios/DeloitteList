using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Repository.Context.Deloitte.Models
{
    public class TaskDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public int CreatedBy { get; set; }
        public List<TaskHistory> TaskHistories { get; set; }
    }
}
