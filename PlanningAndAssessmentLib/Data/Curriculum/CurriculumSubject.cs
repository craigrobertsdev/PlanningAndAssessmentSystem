namespace PlanningAndAssessmentLib.Data.Curriculum;

public class CurriculumSubject
{
    public string Name { get; set; }
    public List<SubjectYearLevel> YearLevels { get; set; }
}

public class SubjectYearLevel
{
    public int YearLevel { get; set; }
    public List<LearningStrand> Strands { get; set; }
    public string AchievementStandard { get; set; }
}

public class LearningStrand
{
    public string Name { get; set; }
    public int YearLevel { get; set; }
    public List<Substrand> Substrands { get; set; } = new();
}

public class Substrand
{
    public string Name { get; set; }
    public LearningStrand Strand { get; set; } = new();
    public List<CurriculumCode> CurriculumCodes { get; set; } = new();
}

public class CurriculumCode
{
    public string Code { get; set; }
    public Substrand Substrand { get; set; } = new();
    public string ContentDescription { get; set; }
    public List<string> Elaborations { get; set; } = new();
}

/*
 * subject contains:
 *  multiple year levels which each contain
 *      multiple strands which each contain
 *          multiple substrands which each contain
 *              multiple curriculum codes which each contain
 *                  multiple content descriptors which each contain
 *                      multiple elaborations
 *
 */
