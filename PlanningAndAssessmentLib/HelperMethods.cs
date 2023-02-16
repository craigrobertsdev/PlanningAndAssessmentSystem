using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningAndAssessmentLib;
public static class HelperMethods
{
    public static string ToTitleCaseWord(this string word)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
    }
    
    public static string ToTitleCaseSentence(this string word)
    {
        string [] wordArr = word.Split(' ');
        wordArr[0] = HelperMethods.ToTitleCaseWord(wordArr[0]);
        return string.Join(" ", wordArr);
    }
}
