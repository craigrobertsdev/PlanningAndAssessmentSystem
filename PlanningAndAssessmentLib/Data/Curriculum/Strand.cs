namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Strand
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual List<Substrand> Substrands { get; set; } = new();

    public virtual YearLevel YearLevel { get; set; }
}
