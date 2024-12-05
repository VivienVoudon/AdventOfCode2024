internal class Day5_2 : Day
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
        var wrongPages = new List<string>();
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
                    wrongPages.Add(inputLines[i]);
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

        var orderedWrongPages = new List<List<string>>();
        foreach (var wrongPage in wrongPages)
        {
            i = 0;
            var pages = wrongPage.Split(',').ToList();
            bool notOrderedYet = true;
            while (i < pages.Count)
            {
                var pagesThatShouldBeBefore = rules.Where(r => r[1] == pages[i]).Select(r => r[0]).ToList();

                var tmpPages = new List<string>(pages);
                var updateDone = false;
                for (var j = i + 1; j < pages.Count; j++)
                {
                    if (pagesThatShouldBeBefore.Contains(pages[j]))
                    {
                        tmpPages.Insert(i, pages[j]);
                        tmpPages.RemoveAt(j + 1);
                        i++;
                        updateDone = true;
                    }
                }

                if (updateDone)
                {
                    pages = tmpPages;
                    i = 0;
                }
                else
                    i++;
            }

            orderedWrongPages.Add(pages);
        }

        result = orderedWrongPages.Select(l =>
        {
            var middlePage = int.Parse(l[l.Count / 2]);
            Console.WriteLine($"Middle page:{middlePage} ({inputLines[i]})");
            return middlePage;
        }).Sum();

        Console.WriteLine(result);
    }
}

