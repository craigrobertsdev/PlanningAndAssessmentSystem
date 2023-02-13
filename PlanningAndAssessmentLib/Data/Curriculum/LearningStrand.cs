namespace PlanningAndAssessmentLib.Data.Curriculum;

public class LearningStrand
{
    public string Name { get; set; }
    public List<Substrand> Substrands { get; set; } = new();
}
