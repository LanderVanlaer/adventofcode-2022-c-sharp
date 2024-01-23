using System.Text;

namespace _10;

public class Crt
{
    private readonly bool[] _crt = new bool[240];

    public int Index { get; private set; }

    public void Set(bool b) => _crt[Index++] = b;

    public string ToDisplayString()
    {
        StringBuilder sb = new();
        for (int i = 0; i < _crt.Length; i++)
        {
            sb.Append(_crt[i] ? '#' : ' ');

            if ((i + 1) % 40 == 0)
                sb.AppendLine();
        }

        return sb.ToString();
    }
}