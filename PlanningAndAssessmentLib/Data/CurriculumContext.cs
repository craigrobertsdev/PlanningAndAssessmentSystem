using PlanningAndAssessmentLib.Data.Curriculum;


namespace PlanningAndAssessmentLib.Data;
public class CurriculumContext : DbContext
{
	public CurriculumContext(DbContextOptions<CurriculumContext> options) : base(options)
	{

	}
	public DbSet<Subject> Subjects { get; set; }

}
