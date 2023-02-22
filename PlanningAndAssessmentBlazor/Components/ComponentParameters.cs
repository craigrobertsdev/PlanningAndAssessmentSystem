namespace PlanningAndAssessmentBlazor.Components;

public class ComponentParameters
{
    public Dictionary<string, object> GetParameterDictionary()
    {
        Dictionary<string, object> parameters = new();
        foreach (var property in this.GetType().GetProperties())
        {
            parameters.Add(property.Name, property.GetValue(this));
        }
        return parameters;
    }
}
