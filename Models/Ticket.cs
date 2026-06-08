using System.ComponentModel.DataAnnotations;

namespace CRM_Ticket_management_system.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty; // Open, InProgress, Closed

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
