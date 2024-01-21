namespace _9;

public class Graph
{
    private readonly Dictionary<(int x, int y), Cell> _cells = new();

    public Cell this[int x, int y]
    {
        get
        {
            if (!_cells.ContainsKey((x, y)))
                AddCell(x, y);

            return _cells[(x, y)];
        }
    }

    public IEnumerable<Cell> Cells => _cells.Values;

    public IEnumerable<Cell> VisitedCells => _cells.Values.Where(c => c.Visits > 0);

    public IEnumerable<Cell> UnvisitedCells => _cells.Values.Where(c => c.Visits == 0);

    public Cell AddCell(int x, int y)
    {
        if (_cells.ContainsKey((x, y)))
            throw new ArgumentException($"Cell ({x}, {y}) already exists");

        Cell cell = new(x, y);
        _cells.Add((x, y), cell);
        return cell;
    }

    public Cell DoAction(Cell cell, Action action)
    {
        return action switch
        {
            Action.Up => this[cell.X, cell.Y - 1],
            Action.Down => this[cell.X, cell.Y + 1],
            Action.Right => this[cell.X + 1, cell.Y],
            Action.Left => this[cell.X - 1, cell.Y],
            Action.UpRight => this[cell.X + 1, cell.Y - 1],
            Action.UpLeft => this[cell.X - 1, cell.Y - 1],
            Action.DownRight => this[cell.X + 1, cell.Y + 1],
            Action.DownLeft => this[cell.X - 1, cell.Y + 1],
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null),
        };
    }
}

public class Cell
{
    public readonly int X;
    public readonly int Y;
    public int Visits;

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Visit() => ++Visits;

    public bool Around(Cell cell)
    {
        for (int x = X - 1; x < X + 2; ++x)
        for (int y = Y - 1; y < Y + 2; ++y)
            if (cell.X == x && cell.Y == y)
                return true;

        return false;
    }

    public Action NextAction(Cell cell)
    {
        int newX = 0;
        int newY = 0;

        if (cell.X < X)
            newX = -1;
        else if (cell.X > X)
            newX = 1;

        if (cell.Y < Y)
            newY = -1;
        else if (cell.Y > Y)
            newY = 1;

        return (newX, newY) switch
        {
            (-1, -1) => Action.UpLeft,
            (-1, 0) => Action.Left,
            (-1, 1) => Action.DownLeft,
            (0, -1) => Action.Up,
            (0, 1) => Action.Down,
            (1, -1) => Action.UpRight,
            (1, 0) => Action.Right,
            (1, 1) => Action.DownRight,
            _ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null),
        };
    }
}