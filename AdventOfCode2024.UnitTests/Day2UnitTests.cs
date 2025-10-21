namespace AdventOfCode2024.UnitTests;

public class Day2UnitTests
{
    private List<List<int>> _testReport = new List<List<int>>()
    {
        new List<int>(){ 7, 6, 4, 2, 1 },   
        new List<int>(){ 1, 2, 7, 8, 9 },
        new List<int>(){ 9, 7, 6, 2, 1 },
        new List<int>(){ 1, 3, 2, 4, 5 },
        new List<int>(){ 8, 6, 4, 4, 1 },
        new List<int>(){ 1, 3, 6, 7, 9 },
    };

    [Test]
    public void CountSafeLevels_ShouldCountSafeLevels()
    {
        var result = Day2.CountSafeLevels(_testReport);
        Assert.That(result, Is.EqualTo(2));
    }
}