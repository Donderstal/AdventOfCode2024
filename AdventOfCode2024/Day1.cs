namespace AdventOfCode2024;

public class Day1
{
    /**
     * Maybe the lists are only off by a small amount!
     * To find out, pair up the numbers and measure how far apart they are.
     * Pair up the smallest number in the left list with the smallest number in the right list, then the second-smallest left number with the second-smallest right number, and so on.
     *
     * To find the total distance between the left list and the right list, add up the distances between all of the pairs you found.
     */

    public static int FindTotalDistance(int[] list1, int[] list2)
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
}