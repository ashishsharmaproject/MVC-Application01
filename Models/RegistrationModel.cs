using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Application01.Models
{
    public class UserRegistrationModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int UID { get; set; }
        public int cid { get; set; }
        public int country { get; set; }
        public int state { get; set; }
    }
}