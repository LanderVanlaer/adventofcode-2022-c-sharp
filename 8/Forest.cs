namespace _8;

public class Forest
{
    public List<Tree[]> Trees { get; } = new();

    public void AddTrees(string trees)
    {
        AddTrees(
            trees
                .Select(tree => new Tree { Height = tree - 0x30 })
                .ToArray()
        );
    }

    public void AddTrees(Tree[] trees)
    {
        Trees.Add(trees);
    }

    public IEnumerable<IEnumerable<Tree>> GetRows() => Trees;

    public IEnumerable<IEnumerable<Tree>> GetColumns()
    {
        return Enumerable
            .Range(0, Trees[0].Length)
            .Select(i => Trees.Select(row => row[i]));
    }

    private static void CalculateViewFor(IEnumerable<Tree> trees)
    {
        int maxHeight = -1;

        foreach (Tree tree in trees)
        {
            if (tree.Height <= maxHeight) continue;
            maxHeight = tree.Height;
            tree.CanBeViewed = true;
        }
    }

    public void CalculateView()
    {
        foreach (IEnumerable<Tree> row in GetRows())
        {
            CalculateViewFor(row);
            CalculateViewFor(row.Reverse());
        }

        foreach (IEnumerable<Tree> column in GetColumns())
        {
            CalculateViewFor(column);
            CalculateViewFor(column.Reverse());
        }
    }

    public int GetViewableTrees()
    {
        return Trees.Sum(row => row.Count(tree => tree.CanBeViewed));
    }
}