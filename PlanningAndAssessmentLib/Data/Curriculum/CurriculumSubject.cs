using System.Reflection.PortableExecutable;

namespace PlanningAndAssessmentLib.Data.Curriculum;

public class CurriculumSubject
{
    public string Name { get; set; }
    public List<SubjectYearLevel> YearLevels { get; set; } = new();
}

public class SubjectYearLevel
{
    public string YearLevel { get; set; }
    public List<LearningStrand> Strands { get; set; } = new();
    public string AchievementStandard { get; set; }
    public string YearLevelDescription { get; set; }
}

public class LearningStrand
{
    public string Name { get; set; }
    public List<Substrand> Substrands { get; set; } = new();
}

public class Substrand
{
    public string Name { get; set; }
    public List<ContentDescription> ContentDescriptions { get; set; } = new();
}

public class ContentDescription
{
    public string Description { get; set; }
    public string CurriculumCode { get; set; }
    public List<string> Elaborations { get; set; } = new();
}
