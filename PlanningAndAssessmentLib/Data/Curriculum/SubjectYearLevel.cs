namespace PlanningAndAssessmentLib.Data.Curriculum;

public class SubjectYearLevel
{
    public string YearLevel { get; set; }
    public List<LearningStrand> Strands { get; set; } = new();
    public string AchievementStandard { get; set; }
    public string YearLevelDescription { get; set; }
}
