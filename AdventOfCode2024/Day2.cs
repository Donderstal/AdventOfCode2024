namespace AdventOfCode2024;

public class Day2
{
    public static List<List<int>> ParseInputFile()
    {
        var inputSplitByLine = InputFileHelper.GetInputFileAndSplitByLine("Day2Input.txt");
        
        return inputSplitByLine.Select(
                    x => x.Split(' ').Select(
                        int.Parse
                    ).ToList()
                ).ToList();
    }
    
    /**
     * The unusual data (your puzzle input) consists of many reports, one report per line.
     * Each report is a list of numbers called levels that are separated by spaces.
     * ...
     * So, a report only counts as safe if both of the following are true:
     * The levels are either all increasing or all decreasing.
     * Any two adjacent levels differ by at least one and at most three.
     */
    public static int CountSafeReports(List<List<int>> input)
    {
        return input.Count(ReportIsSafe);
    }

    private static bool ReportIsSafe(List<int> report)
    {
        if(report[0] == report[1]) return false;
        
        var shouldIncrease = report[0] < report[1];
        var previousLevel = report[0];
            
        foreach (var level in report.Skip(1))
        {
            if ((shouldIncrease && previousLevel >= level)
                || (!shouldIncrease && previousLevel <= level)
                || (Math.Abs(previousLevel - level) > 3))
            {
                return false;
            }
                
            previousLevel = level;
        }

        return true;
    }
}