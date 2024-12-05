internal class Day5_1 : Day
{
    protected override int DayCount => 5;

    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        var i = 0;
        var rules = new List<string[]>();
        while (!string.IsNullOrEmpty(inputLines[i]))
        {
            rules.Add([inputLines[i].Split('|')[0], inputLines[i].Split('|')[1]]);
            i++;
        }

        i++;
        var result = 0;
        while (i < inputLines.Count)
        {
            var forbiddenPages = new List<string>();
            var valid = true;
            var pages = new List<string>();
            foreach (var page in inputLines[i].Split(','))
            {
                if (forbiddenPages.Contains(page))
                {
                    valid = false;
                    break;
                }

                pages.Add(page);
                forbiddenPages.AddRange(rules.Where(r => r[1] == page).Select(r => r[0]));
            }

            if (valid)
            {
                var middlePage = int.Parse(pages[pages.Count / 2]);
                Console.WriteLine($"Middle page:{middlePage} ({inputLines[i]})");
                result += middlePage;
            }

            i++;
        }

        Console.WriteLine(result);
        
    }
}
