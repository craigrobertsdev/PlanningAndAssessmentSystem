namespace PlanningAndAssessmentLib.Data.Curriculum;

public class ContentDescription
{
    public string Description { get; set; }
    public string CurriculumCode { get; set; }
    public List<string> Elaborations { get; set; } = new();
}
