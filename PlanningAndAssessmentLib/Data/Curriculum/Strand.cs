namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Strand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Substrand> Substrands { get; set; } = new();

    public YearLevel YearLevel { get; set; }
}
