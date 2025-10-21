using AdventOfCode2024;

Console.WriteLine("ADVENT OF CODE 2024");
Console.WriteLine("___________________");
Console.WriteLine(Environment.NewLine);

Console.WriteLine("DAY 1");
var day1Input = Day1.ParseInputFile();
Console.WriteLine($"Answer 1: {Day1.FindTotalDistance(day1Input.Item1, day1Input.Item2)}");
Console.WriteLine($"Answer 2: {Day1.FindSimilarityScore(day1Input.Item1, day1Input.Item2)}");
