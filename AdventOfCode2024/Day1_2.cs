// See https://aka.ms/new-console-template for more information
using System.Security.Principal;

internal class Day1_2 : Day
{ 
    protected override int DayCount => 1;

    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

        var left = new List<int>();
        var right = new List<int>();
        
        foreach(var line in inputLines)
        {
            var values = line.Split("   ");
            left.Add(int.Parse(values[0]));
            right.Add(int.Parse(values[1]));
        }

        //left = left.OrderBy(o => o).ToList();
        //right = right.OrderBy(o => o).ToList();
        int total = 0;
        for (var i = 0; i < left.Count; i++)
        {
            //Console.WriteLine($"{left[i]} - {right[i]} = {}");

            total += right.Count(o => o == left[i]) * left[i];
        }

        Console.WriteLine(total);
    }
}