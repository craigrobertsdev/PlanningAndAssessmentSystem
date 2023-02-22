using Microsoft.AspNetCore.Components;
using PlanningAndAssessmentLib.Data.Curriculum;

namespace PlanningAndAssessmentBlazor.Components.Planner;

public class YearPlannerParameters : ComponentParameters
{
    public List<Subject> Subjects { get; set; }
    public string CurrentYearLevel { get; set; }
}
