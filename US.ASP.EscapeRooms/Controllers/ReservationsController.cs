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
    public class ReservationsController : Controller
    {
        private RoomsFacade RoomsFacade { get; }

        public ReservationsController(AppDbContext context, RoomsFacade roomsFacade)
        {
            RoomsFacade = roomsFacade;
        }

        // GET: Reservations/1/Create
        [Route("{RoomId}/Create")]
        public IActionResult Create(int roomId)
        {
            var model = new ReservationsCreateViewModel()
            {
                Room = RoomsFacade.GetById(roomId)
            };
            return View(model);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomId,DateTime,FirstName,LastName,Email,Phone,Description")] Reservation reservation)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(reservation);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Description", reservation.RoomId);
            return View(reservation);
        }

    }
}
