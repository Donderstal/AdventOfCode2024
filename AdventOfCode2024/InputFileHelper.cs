namespace AdventOfCode2024;

public static class InputFileHelper
{
    public static string[] GetInputFileAndSplitByLine(string fileName)
    {
        var file = File.ReadAllText($"Resources/{fileName}");
        return file.Split('\n');
    }
}