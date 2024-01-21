using _9;
using Action = _9.Action;

StreamReader file = new(args[0]);

Graph graph = new();

//0 => head, 9 => tail
Cell[] cells = new Cell[10];

for (int i = 0; i < 10; i++)
    cells[i] = graph[0, 0];

cells[9].Visit();


while (file.ReadLine() is { } line)
{
    Action action = (Action)line[0];
    int steps = int.Parse(line[1..]);

    for (int i = 0; i < steps; i++)
    {
        cells[0] = graph.DoAction(cells[0], action);

        for (int j = 1; j < 10; j++)
            if (!cells[j - 1].Around(cells[j]))
                cells[j] = graph.DoAction(cells[j], cells[j].NextAction(cells[j - 1]));

        cells[9].Visit();
    }
}

Console.WriteLine(graph.VisitedCells.Count());