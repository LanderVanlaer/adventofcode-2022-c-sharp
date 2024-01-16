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

    public void CalculateNumberOfViewableTrees()
    {
        for (int i = 0; i < Trees.Count; i++)
        for (int j = 0; j < Trees[i].Length; j++)
            CalculateNumberOfViewableTrees(i, j);
    }

    private void CalculateNumberOfViewableTrees(int row, int column)
    {
        Tree tree = Trees[row][column];
        tree.ScoreLeft = CalculateNumberOfViewableTrees(row..(row + 1), ..column, tree.Height);
        tree.ScoreRight = CalculateNumberOfViewableTrees(row..(row + 1), (column + 1).., tree.Height);
        tree.ScoreBottom = CalculateNumberOfViewableTrees((row + 1).., column..(column + 1), tree.Height);
        tree.ScoreTop = CalculateNumberOfViewableTrees(..row, column..(column + 1), tree.Height);
    }

    private int CalculateNumberOfViewableTrees(Range rowRange, Range colRange, int height)
    {
        int maxView = 0;

        int rangeStart = rowRange.Start.IsFromEnd ? Trees.Count - rowRange.Start.Value : rowRange.Start.Value;
        int rangeEnd = rowRange.End.IsFromEnd ? Trees.Count - rowRange.End.Value : rowRange.End.Value;

        IEnumerable<Tree[]> rows = Trees.GetRange(rangeStart, rangeEnd - rangeStart);
        if (rangeStart == 0)
            rows = rows.Reverse();

        foreach (Tree[] trees in rows)
        {
            IEnumerable<Tree> cols = trees[colRange];
            if (colRange.Start.Value == 0)
                cols = cols.Reverse();

            foreach (Tree tree in cols)
            {
                ++maxView;

                if (tree.Height >= height)
                    return maxView;
            }
        }

        return maxView;
    }

    public Tree GetTreeWithHighestCount()
    {
        Tree treeWithHighestScore = Trees[0][0];

        foreach (Tree[] trees in Trees)
        foreach (Tree tree in trees)
            if (treeWithHighestScore.Score < tree.Score)
                treeWithHighestScore = tree;

        return treeWithHighestScore;
    }
}