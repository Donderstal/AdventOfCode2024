namespace AdventOfCode2024.UnitTests;

public class Day2UnitTests
{
    private readonly List<List<int>> _testInput =
    [
        [7, 6, 4, 2, 1],
        [1, 2, 7, 8, 9],
        [9, 7, 6, 2, 1],
        [1, 3, 2, 4, 5],
        [8, 6, 4, 4, 1],
        [1, 3, 6, 7, 9]
    ];

    [Test]
    public void CountSafeLevels_ShouldCountSafeLevels()
    {
        var result = Day2.CountSafeReports(_testInput);
        Assert.That(result, Is.EqualTo(2));
    }
}