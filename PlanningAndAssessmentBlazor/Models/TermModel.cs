using PlanningAndAssessmentLib.Data.Curriculum;

namespace PlanningAndAssessmentBlazor.Models;

/// <summary>
/// Used to model the data for each term, including the subjects that will be taught, the topics that will be covered
/// and the events that will be on the calendar. 
/// 
/// Used in the Planner components.
/// </summary>
public class TermModel
{
    public int TermNumber { get; set; }
    public int NumWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Subject> Subjects { get; set; } = new();
    public List<SchoolEvent> SchoolEvents { get; set; } = new();

    public TermModel(int termNumber, DateTime startDate, DateTime endDate, List<Subject> subjects)
    {
        TermNumber = termNumber;
        StartDate = startDate;
        EndDate = endDate;
        Subjects = subjects;

        NumWeeks = CalculateTermLength();
    }

    public int CalculateTermLength()
    {
        // Adds 3 to account for the school term ending on Friday, not Sunday
        return (int)Math.Ceiling((EndDate - StartDate).TotalDays + 3) / 7;
    }

    
}
