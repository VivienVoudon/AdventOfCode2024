using System.Text.RegularExpressions;

internal class Day3_2 : Day
{
    protected override int DayCount => 3;

    private int result = 0;
    protected override void Run(string input)
    {
        bool active = true;
        foreach (Match match in Regex.Matches(input, @"(mul\((\d+),(\d+)\)|do\(\)|don't\(\))"))
        {
            if(match.Groups[0].Value == "don't()")
                active = false;
            else if (match.Groups[0].Value == "do()")
                active = true;
            else if(active)
                result += int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
        }
       
        Console.WriteLine(result);
    }
}