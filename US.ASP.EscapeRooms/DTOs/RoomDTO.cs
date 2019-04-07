using System.Collections.Generic;
using US.ASP.EscapeRooms.DAL.Entities;

namespace US.ASP.EscapeRooms.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OpenFrom { get; set; }
        public int OpenTo { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}