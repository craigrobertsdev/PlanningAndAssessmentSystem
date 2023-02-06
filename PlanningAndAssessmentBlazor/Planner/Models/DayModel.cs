using PlanningAndAssessmentLib.Models;

namespace PlanningAndAssessmentBlazor.Planner.Models;

public class DayModel
{
    public DateTime Date { get; set; }
    public List<Subject> Subjects { get; set; }
}
