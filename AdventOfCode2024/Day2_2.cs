using System.Numerics;

internal class Day2_2 : Day
{
    protected override int DayCount => 2;

    private int result = 0;
    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        List<int[]> V2 = new List<int[]>();

        var restAFaire = Test(inputLines.Select(l => l.Split(' ').Select(int.Parse).ToArray()).ToList(), 1);
        Test(restAFaire, -1);

        //foreach (var report in inputLines)
        //{
        //    var reports = report.Split(' ').Select(int.Parse).ToArray();
        //    int previous = reports[0];
        //    var direction = 0;
        //    var valid = true;
        //    var errorDone = false;
            
        //    for(var i = 1; i < reports.Length; i++)
        //    {
        //        if (Math.Abs(reports[i] - previous) > 3)
        //        {
        //            if (errorDone)
        //            {
        //                valid = false;
        //                break;
        //            }
        //            errorDone = true;
        //            continue;
        //        }

        //        if (direction == 0)
        //        {
        //            if (reports[i] == previous)
        //            {
        //                if (errorDone)
        //                {
        //                    valid = false;
        //                    break;
        //                }
        //                errorDone = true;
        //                V2.Add(reports[1..]);
        //                continue;
        //            }

        //            direction = reports[i] > previous ? 1 : -1;
        //        }
        //        else if(direction == 1 && reports[i] <= previous)
        //        {
        //            if (errorDone)
        //            {
        //                valid = false;
        //                break;
        //            }

        //            if(i == 1)
        //                V2.Add(reports[1..]);
        //            errorDone = true;
        //            continue;
        //        }
        //        else if (direction == -1 && reports[i] >= previous)
        //        {
        //            if (errorDone)
        //            {
        //                valid = false;
        //                break;
        //            }
        //            errorDone = true;
        //            continue;
        //        }

        //        previous = reports[i];
        //    }

        //    if (valid)
        //    {
        //        //Console.WriteLine($"{report} => safe");
        //        result++;
        //    }
        //    else
        //        Console.WriteLine($"{report} => unsafe");
        //}

        //Console.WriteLine($"============");

        //foreach (var reports in V2)
        //{
        //    int previous = reports[0];
        //    var direction = 0;
        //    var valid = true;
        //    var errorDone = false;
            
        //    for(var i = 1; i < reports.Length; i++)
        //    {
        //        if (Math.Abs(reports[i] - previous) > 3)
        //        {
        //            valid = false;
        //            break;
        //        }

        //        if (direction == 0)
        //        {
        //            if (reports[i] == previous)
        //            {

        //                valid = false;
        //                break;
        //            }

        //            direction = reports[i] > previous ? 1 : -1;
        //        }
        //        else if (direction == 1 && reports[i] <= previous)
        //        {
        //            valid = false;
        //            break;
        //        }
        //        else if (direction == -1 && reports[i] >= previous)
        //        {
        //            valid = false;
        //            break;
        //        }

        //        previous = reports[i];
        //    }

        //    if (valid)
        //    {
        //        //Console.WriteLine($"{string.Join(' ', reports)} => safe");
        //        result++;
        //    }
        //    else
        //        Console.WriteLine($"{string.Join(' ', reports)} => unsafe");
        //}


        Console.WriteLine(result);
    }

    public List<int[]> Test(List<int[]> lines, int direction)
    {
        var errorLines = new List<int[]>();
        foreach (var reports in lines)
        {
            int previous = reports[0];
            var valid = true;
            var errorDone = false;
            
            for(var i = 1; i < reports.Length; i++)
            {
                if (Math.Abs(reports[i] - previous) > 3)
                {
                    if (errorDone)
                    {
                        valid = false;
                        break;
                    }
                    errorDone = true;
                    continue;
                }

                if(direction == 1 && reports[i] <= previous)
                {
                    if (errorDone)
                    {
                        valid = false;
                        break;
                    }

                    if(i == 1)
                        errorLines.Add(reports[1..]);
                    errorDone = true;
                    continue;
                }
                else if (direction == -1 && reports[i] >= previous)
                {
                    if (errorDone)
                    {
                        valid = false;
                        break;
                    }
                    errorDone = true;
                    continue;
                }

                previous = reports[i];
            }

            if (valid)
                result++;
        }

        return errorLines;
    }
}