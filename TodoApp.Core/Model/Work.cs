using System;

namespace TodoApp.Core.Model
{
    public class Work:BaseEntity
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
