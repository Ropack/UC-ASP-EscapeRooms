using System;
using System.ComponentModel.DataAnnotations;
using UC.CSP.MeetingCenter.DAL;

namespace US.ASP.EscapeRooms.DAL.Entities
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\+([0-9]{3} ){3}[0-9]{3}$")]
        public string Phone { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}