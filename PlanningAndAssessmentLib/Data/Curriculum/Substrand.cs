namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Substrand
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual List<ContentDescription> ContentDescriptions { get; set; } = new();

    public virtual Strand Strand { get; set; }
}
