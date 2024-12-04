internal class Day4_1 : Day
{
    protected override int DayCount => 4;

    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        var result = 0;
        for (int x = 0; x < inputLines[0].Length; x++)
            for (int y = 0; y < inputLines.Count; y++)
            {
                if(inputLines[y][x] != 'X')
                    continue;

                if (x + 3 < inputLines[0].Length
                    && inputLines[y][x + 1] == 'M'
                    && inputLines[y][x + 2] == 'A'
                    && inputLines[y][x + 3] == 'S')
                    result++;
                
                if (x - 3 >= 0
                    && inputLines[y][x - 1] == 'M'
                    && inputLines[y][x - 2] == 'A'
                    && inputLines[y][x - 3] == 'S')
                    result++;
                
                if (y + 3 < inputLines.Count
                    && inputLines[y + 1][x] == 'M'
                    && inputLines[y + 2][x] == 'A'
                    && inputLines[y + 3][x] == 'S')
                    result++;
                
                if (y - 3 >= 0
                    && inputLines[y - 1][x] == 'M'
                    && inputLines[y - 2][x] == 'A'
                    && inputLines[y - 3][x] == 'S')
                    result++;
                
                if (x + 3 < inputLines[0].Length && y + 3 < inputLines.Count
                    && inputLines[y + 1][x + 1] == 'M'
                    && inputLines[y + 2][x + 2] == 'A'
                    && inputLines[y + 3][x + 3] == 'S')
                    result++;
                
                if (x + 3 < inputLines[0].Length && y - 3 >= 0
                    && inputLines[y - 1][x + 1] == 'M'
                    && inputLines[y - 2][x + 2] == 'A'
                    && inputLines[y - 3][x + 3] == 'S')
                    result++;
                
                if (x - 3 >= 0 && y + 3 < inputLines.Count
                    && inputLines[y + 1][x - 1] == 'M'
                    && inputLines[y + 2][x - 2] == 'A'
                    && inputLines[y + 3][x - 3] == 'S')
                    result++;
                
                if (x - 3 >= 0 && y - 3 >= 0
                    && inputLines[y - 1][x - 1] == 'M'
                    && inputLines[y - 2][x - 2] == 'A'
                    && inputLines[y - 3][x - 3] == 'S')
                    result++;
            }



        Console.WriteLine(result);
        
    }
}
