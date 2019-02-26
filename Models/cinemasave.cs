using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarLight_Ticket.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarLight_Ticket.Models
{
    public class cinemasave
    {

        public int CID_save
        {
            get { return CID_save; }
            set { CID_save = value; }
        }
            public int CinemaID { get { return CinemaID; } set { CinemaID = value; } }
        [Required(ErrorMessage ="Please Fill the text Area")]
        public string UserName { get { return UserName; } set { UserName = value; } }
        [Required(ErrorMessage = "Please Fill the text Area")]
        public string CinemaName { get { return CinemaName; } set { CinemaName = value; } }
        [Required(ErrorMessage = "Please Fill the text Area")]
        public string MovieName { get { return MovieName; } set { MovieName = value; } }
        [Required(ErrorMessage = "Please Fill the text Area")]
        public string Location { get { return Location; } set { Location = value; } }
        [Required(ErrorMessage = "Please Fill the text Area")]
        public DateTime ShowDate { get { return ShowDate; } set { ShowDate = value; } }
        [Required(ErrorMessage = "Please Fill the text Area")]
        public int Quantity { get { return Quantity; } set { Quantity = value; } }
        [Required(ErrorMessage = "Please Fill the text Area")]
        public int Price { get { return Price; } set { Price = value; } }

    }
}