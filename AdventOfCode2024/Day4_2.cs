internal class Day4_2 : Day
{
    protected override int DayCount => 4;

    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        var result = 0;
        for (int x = 1; x < inputLines[0].Length - 1; x++)
            for (int y = 1; y < inputLines.Count - 1; y++)
            {
                if (inputLines[y][x] != 'A')
                    continue;

                int masCount = 0;
                if (inputLines[y - 1][x - 1] == 'M' && inputLines[y + 1][x + 1] == 'S')
                    masCount++;

                if (inputLines[y - 1][x + 1] == 'M' && inputLines[y + 1][x - 1] == 'S')
                    masCount++;

                if (inputLines[y + 1][x - 1] == 'M' && inputLines[y - 1][x + 1] == 'S')
                    masCount++;

                if (inputLines[y + 1][x + 1] == 'M' && inputLines[y - 1][x - 1] == 'S')
                    masCount++;

                if(masCount == 2)
                    result++;
            }



        Console.WriteLine(result);

    }
}
