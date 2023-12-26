StreamReader file = new(args[0]);

int sum = 0;

while (file.ReadLine() is { } line)
{
    int middle = line.Length / 2;

    string left = line[..middle];
    string right = line[middle..];

    char commonItem = FindCommonItem(left, right);

    sum += commonItem - (char.ToLower(commonItem) == commonItem ? 96 : 38);
}


Console.WriteLine(sum);

return;

char FindCommonItem(string left, string right)
{
    foreach (char l in left)
    foreach (char r in right)
        if (l == r)
            return l;

    throw new InvalidOperationException();
}