using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningAndAssessmentLib.DataAccess;

public interface IDataAccess 
{
    Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionString);
    Task SaveData<T>(string sql, T parameters, string connectionString);
}
