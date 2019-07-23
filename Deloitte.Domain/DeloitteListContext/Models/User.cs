using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deloitte.Domain.DeloitteListContext.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastAccessTime { get; set; }
    }
}
