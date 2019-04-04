using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace US.ASP.EscapeRooms.DAL.Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 50)] // I set max length to 1000 characters, because 500 is too few for my description in seed
        public string Description { get; set; }
        [Required]
        [Range(0, 23)]
        public int OpenFrom { get; set; }
        [Required]
        [Range(0, 23)]
        public int OpenTo { get; set; }
        public virtual List<Reservation> Reservations { get; private set; }

        public Room()
        {
            Reservations = new List<Reservation>();
        }
    }
}