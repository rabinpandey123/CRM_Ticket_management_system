using CRM_Ticket_management_system.Data;
using CRM_Ticket_management_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Ticket_management_system.Controllers
{
    [Route("[controller]/[action]")]
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;

        public TicketController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Ticket/Index
        public IActionResult Index()
        {
            var tickets = _context.Tickets.ToList();
            return Ok(tickets);
        }

        // GET: /Ticket/Details/1
        public IActionResult Details(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        // GET: /Ticket/Create
        public IActionResult Create()
        {
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..", "..", "..",
                "wwwroot", "create.html");
            return PhysicalFile(Path.GetFullPath(path), "text/html");
        }

        // POST: /Ticket/Create
        [HttpPost]
        public IActionResult Create([FromForm] Ticket ticket)
        {
            if (string.IsNullOrEmpty(ticket.Title) ||
                string.IsNullOrEmpty(ticket.Description) ||
                string.IsNullOrEmpty(ticket.Status))
            {
                return Redirect("/error.html");
            }

            ticket.CreatedAt = DateTime.Now;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return Redirect("/Ticket/Index");
        }
    }
}