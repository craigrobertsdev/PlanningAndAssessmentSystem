namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Substrand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ContentDescription> ContentDescriptions { get; set; } = new();

    public Strand Strand { get; set; }
}
