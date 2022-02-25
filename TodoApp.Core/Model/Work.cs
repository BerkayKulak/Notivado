using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Model
{
    public class Work:BaseEntity
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
