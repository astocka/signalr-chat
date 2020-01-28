using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeChat.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser(string userName) : base(userName)
        {
            Messages = new HashSet<Message>();
        }

        public AppUser()
        {
            Messages = new HashSet<Message>();
        }

        public Avatar Avatar { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
