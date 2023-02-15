namespace PlanningAndAssessmentLib.Data.Curriculum;

public class YearLevel
{
    public int Id { get; set; }
    public string SubjectYearLevel { get; set; }
    public List<Strand> Strands { get; set; } = new();
    public string AchievementStandard { get; set; }
    public string Description { get; set; }

    public Subject Subject { get; set; }
}
