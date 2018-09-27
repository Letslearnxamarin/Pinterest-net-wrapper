using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class User : Base
    {
        public string Username { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Bio { get; set; }
    }

    public class Users : List<User> { }
}

