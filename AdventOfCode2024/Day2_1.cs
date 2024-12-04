internal class Day2_1 : Day
{
    protected override int DayCount => 2;

    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        var result = 0;
        foreach (var report in inputLines)
        {
            var reports = report.Split(' ').Select(int.Parse).ToArray();
            int previous = reports[0];
            var direction = 0;
            var valid = true;
            foreach (var level in reports.Skip(1).ToArray())
            {
                if (Math.Abs(level - previous) > 3)
                {
                    valid = false;
                    break;
                }

                if (direction == 0)
                {
                    if (level == previous)
                    {
                        valid = false;
                        break;
                    }

                    direction = level > previous ? 1 : -1;
                }
                else if(direction == 1 && level <= previous)
                {
                    valid = false;
                    break;
                }
                else if (direction == -1 && level >= previous)
                {
                    valid = false;
                    break;
                }

                previous = level;
            }

            if (valid)
            {
                Console.WriteLine($"{report} => safe");
                result++;
            }
        }

        Console.WriteLine(result);
    }
}