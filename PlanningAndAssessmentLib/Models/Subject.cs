using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningAndAssessmentLib.Models;

public class Subject
{
    public string Name { get; set; }
    public List<Topic> Topics { get; set; }
}
