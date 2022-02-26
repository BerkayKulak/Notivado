using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.DTOs
{
    public class WorkAddDto
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }

    }
}
