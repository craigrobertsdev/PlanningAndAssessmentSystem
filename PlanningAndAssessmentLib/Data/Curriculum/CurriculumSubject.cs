namespace PlanningAndAssessmentLib.Data.Curriculum;

public class CurriculumSubject
{
    public string Name { get; set; }
    public List<SubjectYearLevel> YearLevels { get; set; } = new();
}
