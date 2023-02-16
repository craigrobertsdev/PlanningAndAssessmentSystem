using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Data;
using PlanningAndAssessmentLib.Data.Curriculum;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace PlanningAndAssessmentLib.Services;

public class CurriculumService
{
    private List<Subject> subjects { get; set; } = new();

    // Read values from each curriculum document and add appropriate information to the database if not already populated.
    public List<Subject> GetCurriculumData()
    {
        string[] files = Directory.GetFiles(
            "C:\\Users\\craig\\source\\repos\\PlanningAndAssessmentSystem\\PlanningAndAssessmentLib\\Data\\CurriculumFiles"
        );
        foreach (string file in files)
        {

            string[] contentArr = LoadFile(file);
            Console.WriteLine(file);

            string subjectName = file.Split("C:\\Users\\craig\\source\\repos\\PlanningAndAssessmentSystem\\PlanningAndAssessmentLib\\Data\\CurriculumFiles\\")[1].Split('-')[0];
            subjectName = HelperMethods.ToTitleCaseWord(subjectName);

            string currElements = "";
            foreach (string content in contentArr)
            {
                if (content == "CURRICULUM ELEMENTS" || content == "Curriculum Elements" || content == "Curriculum elements")
                {
                    currElements = content;
                    break;
                }
            }
            //currElements = contentArr.First(x => x.Equals("CURRICULUM ELEMENTS") || x.Equals("Curriculum Elements"));
            int index = Array.IndexOf(contentArr, currElements) + 1;


            subjects.Add(GetCurriculumSubject(contentArr, subjectName, index));
        }                   
        
        return subjects;
    }

    private string[] LoadFile(string filePath)
    {
        WordDocument document = new();
        using FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        document.Open(stream, FormatType.Docx);

        // parse entire document into string
        string content = document.GetText();

        // create array of individual lines
        string[] contentArr = content.Split("\n");

        // remove all carriage returns from created array
        for (int i = 0; i < contentArr.Length; i++)
        {
            contentArr[i] = contentArr[i].Trim('\r').Trim('\t');
        }

        // remove all empty array entires
        contentArr = contentArr.Where(item => !string.IsNullOrEmpty(item)).ToArray();

        return contentArr;
    }

    private Subject GetCurriculumSubject(string[] contentArr, string subjectName, int index)
    {
        Subject subject = new() { Name = subjectName };

        try
        {
            while (index < contentArr.Length)
            {
                YearLevel yearLevel = ParseYearLevel(contentArr, subjectName, ref index);
                yearLevel.Subject = subject;
                subject.YearLevels.Add(yearLevel);
                // "Australian Curriculum:" appears after all curriculum content for each subject.
                if (contentArr[index].StartsWith("Australian Curriculum:"))
                {
                    break;
                }
            }
        }
        catch (Exception ex) { Console.WriteLine("Index: " + index); }
        return subject;
    }

    private YearLevel ParseYearLevel(string[] contentArr, string subjectName, ref int index)
    {
        YearLevel yearLevel = new()
        {
            // capture  year level
            SubjectYearLevel = contentArr[index]
        };
        index += 2;
        string description = "";

        do
        {
            description += contentArr[index] + "\n\n";
            index++;
        }
        while (!contentArr[index].StartsWith("Achievement standard"));
        yearLevel.Description = description;
        index++;

        // iterate over next x lines to capture the entire achievement standard
        string achievementStandard = "";
        do
        {
            achievementStandard += contentArr[index] + "\n\n";
            index++;
        } while (!contentArr[index].StartsWith("Strand"));

        yearLevel.AchievementStandard = achievementStandard;

        // continue parsing document until the next line doesn't begin with strand.
        while (contentArr[index].StartsWith("Strand"))
        {
            Strand strand = new();
            if (subjectName == "Mathematics")
            {
                strand = GetMathsStrand(contentArr, ref index);
            }
            else
            {
                strand = GetStrand(contentArr, ref index);
            }
            strand.YearLevel = yearLevel;
            yearLevel.Strands.Add(strand);

        }
        
        return yearLevel;
    }

    private Strand GetStrand(string[] contentArr, ref int index)
    {
        Strand strand = new();
        // remove "Strand:" from name
        strand.Name = contentArr[index].Substring(8);
        index += 2;

        while (contentArr[index].StartsWith("Sub-strand"))
        {
            Substrand substrand = new();
            substrand = GetSubstrand(contentArr, ref index);
            substrand.Strand = strand;
            strand.Substrands.Add(substrand);
        }
        return strand;
    }

    private Substrand GetSubstrand(string[] contentArr, ref int index)
    {
        Substrand substrand = new();
        // remove "Sub-strand:" from name
        substrand.Name = contentArr[index].Substring(12);
        if (contentArr[index + 1] == "Content descriptions")
        {
            index += 5;
        }
        else
        {
            index++;
        }
        while (contentArr[index + 1].StartsWith("AC9"))
        {
            ContentDescription contentDescription = GetContentDescriptions(contentArr, ref index);
            contentDescription.Substrand = substrand;
            substrand.ContentDescriptions.Add(contentDescription);
        }

        return substrand;
    }

    private ContentDescription GetContentDescriptions(string[] contentArr, ref int index)
    {
        ContentDescription contentDescription = new();
        contentDescription.Description = HelperMethods.ToTitleCaseSentence(contentArr[index]);
        index++;

        contentDescription.CurriculumCode = contentArr[index];
        index++;

        while (contentArr[index].StartsWith("*"))
        {
            Elaboration elaboration = new();
            elaboration.Content = contentArr[index].Substring(2);
            elaboration.ContentDescription = contentDescription;
            contentDescription.Elaborations.Add(elaboration);
            index++;
        }

        return contentDescription;
    }

    // Maths is dealt with differently as there are no substrands in the curriculum
    /*
     * This function will create a placeholder substrand to keep the object model consistent 
     * Iterate over the content descriptions and add them the dummy substrand
     * return the completed strand
     */
    private Strand GetMathsStrand(string[] contentArr, ref int index)
    {
        Strand strand = new();
        Substrand substrand = new()
        {
            Strand = strand
        };

        index += 6;

        while (contentArr[index + 1].StartsWith("AC9"))
        {
            ContentDescription contentDescription = GetContentDescriptions(contentArr, ref index);
            contentDescription.Substrand = substrand;
            substrand.ContentDescriptions.Add(contentDescription);
        }
        strand.Substrands.Add(substrand);
        return strand;
    }

}

