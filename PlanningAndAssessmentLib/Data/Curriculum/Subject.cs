namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Subject
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual List<YearLevel> YearLevels { get; set; } = new();
}
