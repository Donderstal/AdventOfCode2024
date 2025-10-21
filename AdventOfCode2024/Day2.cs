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
        var safeReports = 0;
        
        // Loop through the levels in the report
        foreach (var report in input)
        {
            // We can skip the level if the first two are equal
            if(report[0] == report[1])
                continue;
            
            var reportIsSafe = true;
            
            // Determine if the first and second element have a increasing or decreasing distance
            var shouldIncrease = report[0] < report[1];
            var previousLevel = report[0];
            
            foreach (var level in report.Skip(1))
            {
                // Then, keep track if all next steps in the level:
                // - Are within the 1 3 range
                // - Are all increasing/decreasing like the first
                if ((shouldIncrease && previousLevel >= level)
                    || (!shouldIncrease && previousLevel <= level)
                    || (Math.Abs(previousLevel - level) > 3))
                {
                    reportIsSafe = false;
                    break;
                }
                
                previousLevel = level;
            }
            
            // If the level satisfies our condition, add one to our return value
            if(reportIsSafe) safeReports++;
        }
        
        return safeReports;
    }
}