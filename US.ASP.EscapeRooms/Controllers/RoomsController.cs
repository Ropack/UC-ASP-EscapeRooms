using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UC.CSP.MeetingCenter.DAL;
using US.ASP.EscapeRooms.DAL.Entities;
using US.ASP.EscapeRooms.Facades;
using US.ASP.EscapeRooms.ViewModels;

namespace US.ASP.EscapeRooms.Controllers
{
    [Route("[controller]")]
    public class RoomsController : Controller
    {
        private RoomsFacade RoomsFacade { get; }

        public RoomsController(AppDbContext context, RoomsFacade roomsFacade)
        {
            RoomsFacade = roomsFacade;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            var model = new RoomsIndexViewModel()
            {
                Rooms = RoomsFacade.GetAll()
            };
            return View(model);
        }

        // GET: Rooms/5
        [Route("{id}")]
        public IActionResult New(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = RoomsFacade.GetById(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

    }
}
