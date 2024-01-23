namespace _10;

public class Sprite
{
    private int _index;
    public int Size { get; init; } = 3;

    public bool IsSet(int i)
    {
        i %= 40;
        return _index <= i && i < _index + Size;
    }

    public void Add(int i) => _index += i;
}