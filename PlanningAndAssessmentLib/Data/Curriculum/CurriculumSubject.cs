namespace PlanningAndAssessmentLib.Data.Curriculum;

public class CurriculumSubject
{
    public string Name { get; set; }
    public int YearLevel { get; set; }
    public string YearLevelDescription { get; set; }
    public Dictionary<string, List<LearningOutcome>> ContentDescriptions { get; set; } = new();
}
