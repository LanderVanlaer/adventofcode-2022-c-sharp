namespace _8;

public class Tree
{
    public int Height { get; init; }
    public int Score => ScoreLeft * ScoreTop * ScoreRight * ScoreBottom;
    public int ScoreLeft { get; set; }
    public int ScoreTop { get; set; }
    public int ScoreRight { get; set; }
    public int ScoreBottom { get; set; }
}