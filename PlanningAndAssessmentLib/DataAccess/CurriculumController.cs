using PlanningAndAssessmentLib.Data;
using PlanningAndAssessmentLib.Data.Curriculum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningAndAssessmentLib.DataAccess;
public class CurriculumController
{
    private readonly IDbContextFactory<CurriculumContext> contextFactory;

    public CurriculumController(IDbContextFactory<CurriculumContext> factory)
	{
        contextFactory = factory;
    }

    // Loads the entire curriculum including all subset data
    public List<Subject> GetCurriculum()
    {
        using var context = contextFactory.CreateDbContext();

        var subjects = context.Subjects
            .Include(subject => subject.YearLevels)
            .ThenInclude(yearLevel => yearLevel.Strands)
            .ThenInclude(strand => strand.Substrands)
            .ThenInclude(substrand => substrand.ContentDescriptions)
            .ThenInclude(contentDescription => contentDescription.Elaborations)
            .ToList();

        return subjects;
    }

    public async Task SaveCurriculum(List<Subject> curriculum)
    {
        using var context = contextFactory.CreateDbContext();
        foreach(var subject in curriculum)
        {
            await context.Subjects.AddAsync(subject);
        }
        context.SaveChanges();
    }

    public void DeleteCurriculum()
    {
        using var context = contextFactory.CreateDbContext();

        foreach(var subject in context.Subjects)
        {
            context.Subjects.Remove(subject);
        }

        context.SaveChanges();
    }
}
