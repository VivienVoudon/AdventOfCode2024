using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2024.Tooling;

internal class Day6_1 : Day
{
    protected override int DayCount => 6;

    private int[,] visitedPos;
    protected override void Run(string input)
    {
        var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

        visitedPos = new int[inputLines.Count, inputLines[0].Length];
        Point gardienPos = new Point(0,0);
        for(var y = 0; y < inputLines.Count; y++)
            for(var x = 0; x < inputLines[y].Length; x++)
            {
                if (inputLines[y][x] == '<'
                    || inputLines[y][x] == '>'
                    || inputLines[y][x] == '^'
                    || inputLines[y][x] == 'v')
                {
                    gardienPos = new Point(x, y);
                    break;
                }

                visitedPos[y, x] = 0;
            }

        var gardienDirection = GetDirection(inputLines[gardienPos.Y][gardienPos.X]);

        while (true)
        {
            switch (gardienDirection)
            {
                case Direction.Top:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X, gardienPos.Y - 1)))
                            gardienPos.Y--;
                        else
                            break;
                    } while (Inbound(gardienPos) && inputLines[gardienPos.Y][gardienPos.X] != '#');
                    gardienDirection = Direction.Right;
                    break;

                case Direction.Bottom:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X, gardienPos.Y + 1)))
                            gardienPos.Y++;
                        else
                            break;
                    } while (Inbound(gardienPos) && inputLines[gardienPos.Y][gardienPos.X] != '#');
                    gardienDirection = Direction.Left;
                    break;

                case Direction.Left:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X - 1, gardienPos.Y)))
                            gardienPos.X--;
                        else
                            break;
                    } while (Inbound(gardienPos) && inputLines[gardienPos.Y][gardienPos.X] != '#');
                    gardienDirection = Direction.Top;
                    break;

                case Direction.Right:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X + 1, gardienPos.Y)))
                            gardienPos.X++;
                        else
                            break;
                    } while (Inbound(gardienPos) && inputLines[gardienPos.Y][gardienPos.X] != '#');
                    gardienDirection = Direction.Bottom;
                    break;
            }

            if(!Inbound(gardienPos))
                break;
        }

        var result = 0;
        for(var y = 0; y < visitedPos.GetLength(0); y++)
        for(var x = 0; x < visitedPos.GetLength(1); x++)
            result += visitedPos[y, x];

        Console.WriteLine(result);
        
    }

    private bool Inbound(Point gardienPos)
    {
        return gardienPos.Y < visitedPos.GetLength(0) && gardienPos.X < visitedPos.GetLength(1);
    }

    private void FillPath(Point gardienPos)
    {
        visitedPos[gardienPos.Y, gardienPos.X] = 1;
    }

    private Direction GetDirection(char gardienPosValue)
    {
        return gardienPosValue switch 

        {
            '<' => Direction.Left,
            '>' => Direction.Right,
            '^' => Direction.Top,
            'v' => Direction.Bottom,
            _ => throw new Exception("Invalid gardien position")
        };
    }
}
