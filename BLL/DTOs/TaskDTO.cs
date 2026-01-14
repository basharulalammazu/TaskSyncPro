using System.ComponentModel.DataAnnotations;

public class TaskDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [StringLength(20)]
    public string Priority { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; }

    public int? AssignedEmployeeId { get; set; }

    [Required]
    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime DueDate { get; set; }

    public DateTime? CompletedAt { get; set; }
}
