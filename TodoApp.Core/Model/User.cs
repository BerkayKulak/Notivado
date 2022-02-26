using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TodoApp.Core.Model
{
    public class User:IdentityUser
    {
        public ICollection<Work> Works { get; set; }

    }
}
