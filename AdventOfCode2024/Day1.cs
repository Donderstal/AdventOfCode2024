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
        
        // Order both lists ascendingly
        var sortedList1 = list1.OrderBy(x => x).ToArray();
        var sortedList2 = list2.OrderBy(x => x).ToArray();
        
        // Loop through the lists from the start
        for (int i = 0; i < sortedList1.Length; i++)
        {
            var item1 = sortedList1[i];
            var item2 = sortedList2[i];
            
            // Compare the numbers to find the distance
            // Add up the numbers to our return value
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
        
        // First fetch all the unique numbers in the leftList
        foreach (var leftItem in leftList)
        {
            // Add our leftItem int as a key with value 0 if not present
            similarityMap.TryAdd(leftItem, 0);
        }

        // Then, search through the rightlist
        foreach (var rightItem in rightList.Where(rightItem => similarityMap.ContainsKey(rightItem)))
        {
            // Keep track of how many times each left number appears
            similarityMap[rightItem]++;
        }

        // Then, multiply each unique leftlist number by their appearances in rightlist
        // Sum the results and return them
        return leftList.Sum(item => similarityMap[item] * item);
    }
}