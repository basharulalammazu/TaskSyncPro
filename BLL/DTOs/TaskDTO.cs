using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [StringLength(20, ErrorMessage = "Priority must be within 20 characters.")]
        public string Priority { get; set; }
        // Allowed: Low, Medium, High

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status must be within 20 characters.")]
        public string Status { get; set; }
        // Allowed: Pending, InProgress, Completed, Overdue

        public int? AssignedEmployeeId { get; set; }

        [Required(ErrorMessage = "Creator is required.")]
        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Due date is required.")]
        public DateTime DueDate { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}
