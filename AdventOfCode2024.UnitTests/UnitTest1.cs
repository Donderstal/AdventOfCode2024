namespace AdventOfCode2024.UnitTests;

public class Tests
{
    [Test]
    [TestCase(new[]{ 3, 4, 2, 1, 3, 3}, new[]{ 4, 3, 5, 3, 9, 3}, 11)]
    public void FindTotalDistance_ShouldFindDistance(int[] list1, int[] list2, int expected)
    {
        var result = Day1.FindTotalDistance(list1.ToList(), list2.ToList());
        Assert.That(result, Is.EqualTo(expected));
    }
}