namespace PlanningAndAssessmentLib.Data.Curriculum;

public class ContentDescription
{
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string CurriculumCode { get; set; }
    public virtual List<Elaboration> Elaborations { get; set; } = new();

    public virtual Substrand Substrand { get; set; }
}
