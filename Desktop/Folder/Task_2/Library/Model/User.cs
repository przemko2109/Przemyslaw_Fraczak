using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Models
{
    public class User
    {
        public User(int id)
        {
            UserId = id;
            Name = DataService.getUser(id).user_name;
        }
        public User(int id, string name)
        {
            UserId = id;
            Name = name;
        }
        public String Name { get; set; }
        public int UserId { get; set; }
    }
}
