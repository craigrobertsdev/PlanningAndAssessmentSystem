namespace PlanningAndAssessmentLib.Data.Curriculum;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<YearLevel> YearLevels { get; set; } = new();
}
