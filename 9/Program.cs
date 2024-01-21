using _9;
using Action = _9.Action;

StreamReader file = new(args[0]);

Graph graph = new();
Cell head = graph[0, 0];
Cell tail = head;

while (file.ReadLine() is { } line)
{
    Action action = (Action)line[0];
    int steps = int.Parse(line[1..]);

    for (int i = 0; i < steps; i++)
    {
        head = graph.DoAction(head, action);

        if (!head.Around(tail))
            tail = graph.DoAction(tail, tail.NextAction(head));

        tail.Visit();
    }
}

Console.WriteLine(graph.VisitedCells.Count());