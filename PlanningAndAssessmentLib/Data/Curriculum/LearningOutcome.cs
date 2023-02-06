namespace PlanningAndAssessmentLib.Data.Curriculum;

public class LearningOutcome
{
    public string CurriculumStandard { get; set; }
    public List<string> Elaborations { get; set; } = new();
}
