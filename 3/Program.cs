StreamReader file = new(args[0]);

int sum = 0;

while (file.ReadLine() is { } line)
    sum += FindCommonItem(
        line,
        file.ReadLine() ?? throw new InvalidOperationException(),
        file.ReadLine() ?? throw new InvalidOperationException()
    );


Console.WriteLine(sum);

return;

int FindCommonItem(params string[] lines)
{
    int[] chars = new int[26 * 2];

    foreach (string line in lines)
    {
        int[] charsOfLines = new int[26 * 2];

        foreach (char c in line)
            charsOfLines[c - (char.ToLower(c) == c ? 97 : 39)] = 1;

        for (int i = 0; i < chars.Length; ++i)
            chars[i] += charsOfLines[i];
    }

    for (int i = 0; i < chars.Length; ++i)
        if (chars[i] == lines.Length)
            return i + 1;

    throw new InvalidOperationException();
}