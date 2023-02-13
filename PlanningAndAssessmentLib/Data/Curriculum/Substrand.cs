namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Substrand
{
    public string Name { get; set; }
    public List<ContentDescription> ContentDescriptions { get; set; } = new();
}
