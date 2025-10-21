namespace AdventOfCode2024;

public class Day1
{
    public static (List<int>, List<int>) ParseInputFile()
    {
        var inputSplitByLine = InputFileHelper.GetInputFileAndSplitByLine("Day1Input.txt");
        
        List<int> leftList =  [];
        List<int> rightList =  [];
        
        foreach (var line in inputSplitByLine)
        {
            var split = line.Split("   ");
            leftList.Add(int.Parse(split[0]));
            rightList.Add(int.Parse(split[1]));
        }
        
        return (leftList, rightList);
    }
    
    /**
     * Maybe the lists are only off by a small amount!
     * To find out, pair up the numbers and measure how far apart they are.
     * Pair up the smallest number in the left list with the smallest number in the right list, then the second-smallest left number with the second-smallest right number, and so on.
     *
     * To find the total distance between the left list and the right list, add up the distances between all of the pairs you found.
     */

    public static int FindTotalDistance(List<int> list1, List<int> list2)
    {
        var totalDistance = 0;
        
        var sortedList1 = list1.OrderBy(x => x).ToArray();
        var sortedList2 = list2.OrderBy(x => x).ToArray();
        
        for (int i = 0; i < sortedList1.Length; i++)
        {
            var item1 = sortedList1[i];
            var item2 = sortedList2[i];
            
            totalDistance += Math.Abs(item1 - item2);
        }
        
        return totalDistance;
    }
    
    /**
     * This time, you'll need to figure out exactly how often each number from the left list appears in the right list.
     * Calculate a total similarity score by adding up each number in the left list after multiplying it by the number of times that number appears in the right list.
     */
    public static int FindSimilarityScore(List<int> leftList, List<int> rightList)
    {
        var similarityMap = new Dictionary<int, int>();
        
        foreach (var leftItem in leftList)
        {
            similarityMap.TryAdd(leftItem, 0);
        }
        
        foreach (var rightItem in rightList.Where(rightItem => similarityMap.ContainsKey(rightItem)))
        {
            similarityMap[rightItem]++;
        }
        
        return leftList.Sum(item => similarityMap[item] * item);
    }
}