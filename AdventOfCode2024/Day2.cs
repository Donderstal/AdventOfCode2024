namespace AdventOfCode2024;

public class Day2
{
    public static List<List<int>> ParseInputFile()
    {
        var input = File.ReadAllText("Resources/Day2Input.txt");
        var splitByLine = input.Split('\n');
        
        return splitByLine.Select(
                    x => x.Split(' ').Select(
                        y => int.Parse(y)
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
    public static int CountSafeLevels(List<List<int>> report)
    {
        var safeLevels = 0;

        var previousElement = -1;
        
        // Loop through the levels in the report
        foreach (var level in report)
        {
            // We can skip the level if the first two are equal
            if(level[0] == level[1])
                continue;
            
            var levelIsSafe = true;
            bool shouldIncrease = level[0] < level[1];
            
            // Determine if the first and second element have a increasing or decreasing distance
            
            foreach (var element in level)
            {
                if (previousElement != -1)
                {
                    // Then, keep track if all next steps in the level:
                    // - Are within the 1 3 range
                    // - Are all increasing/decreasing like the first
                    if ((shouldIncrease && previousElement >= element)
                        || (!shouldIncrease && previousElement <= element)
                        || (Math.Abs(previousElement - element) > 3))
                    {
                        levelIsSafe = false;
                        break;
                    }
                }    
                
                previousElement = element;
            }
            
            previousElement = -1;
            // If the level satisfies our condition, add one to our return value
            if(levelIsSafe) safeLevels++;
        }
        
        return safeLevels;
    }
}