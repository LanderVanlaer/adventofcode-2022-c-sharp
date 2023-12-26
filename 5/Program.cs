using System.Text.RegularExpressions;

StreamReader file = new(args[0]);

CargoCrane crane = new();
crane.Initialize(file);
crane.MoveCargo(file);

Console.WriteLine(crane.TopRow);

internal partial class CargoCrane
{
    private readonly List<Stack<char>> _stacks = new();

    public string TopRow => string.Join("", _stacks.Select(s => s.Count > 0 ? s.Peek().ToString() : " "));

    public void Initialize(StreamReader file)
    {
        List<Stack<char>> stacks = new();

        while (file.ReadLine() is { } line)
        {
            if (line[1] == '1')
                break;

            for (int i = 0; i * 4 < line.Length; ++i)
            {
                //[J]             [F] [M]
                //-----------------------
                //[J] [ ] [ ] [ ] [F] [M]
                // 1   2   3   4   5   6

                if (stacks.Count <= i) stacks.Add(new Stack<char>());

                char c = line.Substring(i * 4, 2)[1];

                if (c != ' ')
                    stacks[i].Push(c);
            }
        }

        //empty line
        file.ReadLine();

        foreach (Stack<char> queue in stacks)
        {
            Stack<char> stack = new();
            while (queue.Count > 0)
                stack.Push(queue.Pop());

            _stacks.Add(stack);
        }
    }

    public void MoveCargo(StreamReader file)
    {
        // move 17 from 7 to 4

        while (file.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                break;
            Match value = MyRegex().Match(line);

            int count = int.Parse(value.Groups[1].Value);
            int from = int.Parse(value.Groups[2].Value) - 1;
            int to = int.Parse(value.Groups[3].Value) - 1;


            for (int i = 0; i < count; ++i)
                _stacks[to].Push(_stacks[from].Pop());
        }
    }

    [GeneratedRegex(@"move (\d+) from (\d+) to (\d+)")]
    private static partial Regex MyRegex();
}