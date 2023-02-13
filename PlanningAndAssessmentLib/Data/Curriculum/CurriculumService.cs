﻿using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Data;

namespace PlanningAndAssessmentLib.Data.Curriculum;

public class CurriculumService
{
    public List<CurriculumSubject> Subjects { get; set; } = new();

    // Read values from each curriculum document and add appropriate information to the database if not already populated.
    public void GetCurriculumData()
    {
        string[] files = Directory.GetFiles(
            "C:\\Users\\craig\\source\\repos\\PlanningAndAssessmentSystem\\PlanningAndAssessmentLib\\Data\\CurriculumFiles"
        );

        foreach (string file in files)
        {
            string[] contentArr = LoadFile(file);
            string? currElements = contentArr.First(x => x.Equals("CURRICULUM ELEMENTS"));
            int index = Array.IndexOf(contentArr, currElements) + 1;

            Subjects.Add(GetCurriculumSubject(contentArr, index));
        }
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

    private CurriculumSubject GetCurriculumSubject(string[] contentArr, int index)
    {
        CurriculumSubject subject = new() { Name = "English" };

        while (index < contentArr.Length)
        {
            SubjectYearLevel yearLevel = new();
            yearLevel = ParseYearLevel(contentArr, ref index);
            subject.YearLevels.Add(yearLevel);
            // "Australian Curriculum:" appears after all curriculum content for each subject.
            if (contentArr[index].StartsWith("Australian Curriculum:"))
            {
                break;
            }
        }

        return subject;
    }

    private SubjectYearLevel ParseYearLevel(string[] contentArr, ref int index)
    {
        SubjectYearLevel yearLevel = new();

        // capture  year level
        yearLevel.YearLevel = contentArr[index];
        index += 2;
        yearLevel.YearLevelDescription = contentArr[index];

        // iterate over next x lines to capture the entire achievement standard
        string achievementStandard = "";
        do
        {
            achievementStandard += contentArr[index];
            index++;
        } while (!contentArr[index].StartsWith("Strand"));

        yearLevel.AchievementStandard = achievementStandard;

        // continue parsing document until the next line doesn't begin with strand.
        while (contentArr[index].StartsWith("Strand"))
        {
            LearningStrand strand = GetStrand(contentArr, ref index);
            yearLevel.Strands.Add(strand);
        }
        return yearLevel;
    }

    private LearningStrand GetStrand(string[] contentArr, ref int index)
    {
        LearningStrand strand = new();
        // remove "Strand:" from name
        strand.Name = contentArr[index].Substring(6);
        index += 2;

        while (contentArr[index].StartsWith("Sub-strand"))
        {
            Substrand substrand = GetSubstrand(contentArr, ref index);
            strand.Substrands.Add(substrand);
        }
        return strand;
    }

    private Substrand GetSubstrand(string[] contentArr, ref int index)
    {
        Substrand substrand = new();
        // remove "Sub-strand:" from name
        substrand.Name = contentArr[index].Substring(11);
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
            substrand.ContentDescriptions.Add(contentDescription);
        }

        return substrand;
    }

    private ContentDescription GetContentDescriptions(string[] contentArr, ref int index)
    {
        ContentDescription contentDescription = new();
        contentDescription.Description = contentArr[index];
        index++;

        contentDescription.CurriculumCode = contentArr[index];
        index++;

        while (contentArr[index].StartsWith("*"))
        {
            contentDescription.Elaborations.Add(contentArr[index].Substring(2));
            index++;
        }

        return contentDescription;
    }
}
