using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarLight_Ticket.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstNAme { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
    }
}