using System.Text.RegularExpressions;

internal class Day3_1 : Day
{
    protected override int DayCount => 3;

    private int result = 0;
    protected override void Run(string input)
    {

        foreach (Match match in Regex.Matches(input, @"mul\((\d+),(\d+)\)"))
        {
            result += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        }
       
        Console.WriteLine(result);
    }
}