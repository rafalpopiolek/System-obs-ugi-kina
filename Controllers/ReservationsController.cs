#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;


namespace WebApplication1.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ReservationsController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations.Include(r => r.Seat).Include(r => r.Show);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Seat)
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create(int id)
        {
            //ViewData["SeatId"] = new SelectList(_context.Seats.Where(s => s.isOccupied == false), "Id", "SeatNumber");

            IEnumerable<SelectListItem> seats = _context.Seats.Where(s => s.isOccupied == false).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = "Miejsce: " + c.SeatNumber
            });

            ViewData["SeatId"] = seats;

            //ViewData["ShowId"] = new SelectList(_context.Shows.Include(s => s.Movie), "Id", "Movie.Name");

            IEnumerable<SelectListItem> items = _context.Shows.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Movie.Name + $" -> dnia: [{c.MovieStart}] "
            });

            ViewData["ShowId"] = items;

            //ViewData["ShowId"] = id;

            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeatId,ShowId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var user = await _usermanager.GetUserAsync(User);
                var userId = user.Id;
                reservation.ApplicationUserId = Guid.Parse(userId);

                //reservation.ShowId = 38;

                _context.Add(reservation);

                await _context.SaveChangesAsync();

                // Ustaw flage isOccupied na True
                var result = _context.Seats.SingleOrDefault(s => s.Id == reservation.SeatId);
                if (result != null)
                {
                    result.isOccupied = true;
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Home", new { area = "" });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["SeatId"] = new SelectList(_context.Seats, "Id", "Id", reservation.SeatId);

            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["SeatId"] = new SelectList(_context.Seats, "Id", "Id", reservation.SeatId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", reservation.ShowId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowId,SeatId,Paid,active")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeatId"] = new SelectList(_context.Seats, "Id", "Id", reservation.SeatId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", reservation.ShowId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Seat)
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }

        // GET: MyReservations
        public async Task<IActionResult> MyReservations()
        {
            var user = await _usermanager.GetUserAsync(User);
            var userId = user.Id;
            var UserId = Guid.Parse(userId);

            var applicationDbContext = _context.Reservations.Include(r => r.Seat).Include(r => r.Show).Where(s => s.ApplicationUserId == UserId);

           return View(await applicationDbContext.ToListAsync());
        }
    }
}
