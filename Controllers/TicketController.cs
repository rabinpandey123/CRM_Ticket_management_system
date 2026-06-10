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
    }
}