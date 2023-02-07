namespace PlanningAndAssessmentLib.Data.Curriculum;
using ExcelDataReader;
using Microsoft.VisualBasic;
using PlanningAndAssessmentLib.Models;
using System.Data;
using System.Net.Http.Headers;

public class CurriculumService
{
    public CurriculumService() { }

    // Read values from local spreadsheet and add appropriate information to the database if not already populated.
    public async Task GetCurriculumData()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        using var stream = File.Open(
            "C:\\Users\\craig\\source\\repos\\PlanningAndAssessmentSystem\\PlanningAndAssessmentLib\\Data\\ExcelData\\Australian Curriculum F-10.xlsx",
            FileMode.Open,
            FileAccess.Read
        );

        using var reader = ExcelReaderFactory.CreateReader(stream);

        var result = reader.AsDataSet();

        List<DataRow> englishData = new();

        for (int i = 2; i <= 790; i++) { }

        /*
         * column0 = Subject name
         * column4 = year level
         * column5 = strand
         * column6 = substrand
         * column10 = curriculum code
         * column11 = content descriptors
         * column12 = elaboration
         */
        Console.WriteLine(rows);
    }
}
