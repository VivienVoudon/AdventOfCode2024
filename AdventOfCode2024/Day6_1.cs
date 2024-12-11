using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2024.Tooling;

internal class Day6_1 : Day
{
    protected override int DayCount => 6;

    private int[,] visitedPos;
    private Point gardienPos;
    private List<string> inputLines;
    private Direction gardienDirection;
    protected override void Run(string input)
    {
        inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

        visitedPos = new int[inputLines.Count, inputLines[0].Length];
        gardienPos = new Point(0,0);
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

        gardienDirection = GetDirection(inputLines[gardienPos.Y][gardienPos.X]);

        while (true)
        {
            //Thread.Sleep(500);
            switch (gardienDirection)
            {
                case Direction.Top:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X, gardienPos.Y - 1)) && inputLines[gardienPos.Y-1][gardienPos.X] != '#')
                            gardienPos.Y--;
                        else
                            break;
                    } while (true);
                    gardienDirection = Direction.Right;
                    break;

                case Direction.Bottom:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X, gardienPos.Y + 1)) && inputLines[gardienPos.Y+1][gardienPos.X] != '#')
                            gardienPos.Y++;
                        else
                            break;
                    } while (true);
                    gardienDirection = Direction.Left;
                    break;

                case Direction.Left:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X - 1, gardienPos.Y)) && inputLines[gardienPos.Y][gardienPos.X-1] != '#')
                            gardienPos.X--;
                        else
                            break;
                    } while (true);
                    gardienDirection = Direction.Top;
                    break;

                case Direction.Right:
                    do
                    {
                        FillPath(gardienPos);
                        if (Inbound(new Point(gardienPos.X + 1, gardienPos.Y)) && inputLines[gardienPos.Y][gardienPos.X+1] != '#')
                            gardienPos.X++;
                        else
                            break;
                    } while (true);
                    gardienDirection = Direction.Bottom;
                    break;
            }

            //Show();

            if(gardienDirection == Direction.Left && gardienPos.Y == visitedPos.GetLength(0) - 1
               || gardienDirection == Direction.Right && gardienPos.Y == 0
               || gardienDirection == Direction.Bottom && gardienPos.X == visitedPos.GetLength(1) - 1
               || gardienDirection == Direction.Top && gardienPos.X == 0
               )
                break;
        }

        var result = 0;
        for(var y = 0; y < visitedPos.GetLength(0); y++)
        for(var x = 0; x < visitedPos.GetLength(1); x++)
            result += visitedPos[y, x];

        Console.WriteLine(result);
        
    }

    private void Show()
    {
        Console.Clear();

        for (var y = 0; y < inputLines.Count; y++)
        {
            string line = string.Empty;
            for (var x = 0; x < inputLines[y].Length; x++)
            {
                if (inputLines[y][x] == '.' && gardienPos.X == x && gardienPos.Y == y)
                    line += gardienDirection switch
                    {
                        Direction.Bottom => 'v',
                        Direction.Left => '<',
                        Direction.Right => '>',
                        Direction.Top => '^',
                    };
                else if(visitedPos[y, x] == 1)
                    line += 'O';
                else
                    line += inputLines[y][x];
            }
            Console.WriteLine(line);
        }
    }

    private bool Inbound(Point gardienPos)
    {
        return gardienPos.Y < visitedPos.GetLength(0) && gardienPos.X < visitedPos.GetLength(1)
            && gardienPos.Y >= 0 && gardienPos.X >= 0;
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
