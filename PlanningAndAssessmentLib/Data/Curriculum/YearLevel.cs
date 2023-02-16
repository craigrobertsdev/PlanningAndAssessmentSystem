using System.ComponentModel.DataAnnotations;

namespace PlanningAndAssessmentLib.Data.Curriculum;

public class YearLevel
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string SubjectYearLevel { get; set; }
    public virtual List<Strand> Strands { get; set; } = new();
    [Required]
    public string AchievementStandard { get; set; }
    [Required]
    public string Description { get; set; }

    public virtual Subject Subject { get; set; }
}
