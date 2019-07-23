using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Repository.Context.Deloitte.Models
{
    public class TaskHistory
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public int TaskDetailId { get; set; }
    }
}
