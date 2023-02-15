using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningAndAssessmentLib.Data.Curriculum;
public class Elaboration
{
    public int Id { get; set; }
    public string Content { get; set; }

    public virtual ContentDescription ContentDescription { get; set; }
}
