using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Model
{
    public class TaskHistoryViewModel
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public int TaskDetailId { get; set; }
    }
}
