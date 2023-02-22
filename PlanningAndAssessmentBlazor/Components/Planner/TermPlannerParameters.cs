using Microsoft.AspNetCore.Components;

namespace PlanningAndAssessmentBlazor.Components.Planner;

public class TermPlannerParameters : ComponentParameters
{
    public int NumWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
