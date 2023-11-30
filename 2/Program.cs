StreamReader file = new(args[0]);

Dictionary<char, char> convert = new()
{
    { 'A', 'X' },
    { 'B', 'Y' },
    { 'C', 'Z' },
};
Dictionary<char, char> wins = new()
{
    { 'X', 'Y' },
    { 'Y', 'Z' },
    { 'Z', 'X' },
};

int points = 0;

while (file.ReadLine() is { } line)
{
    char opponent = convert[line[0]];
    char self = line[2];

    points += self switch
    {
        'X' => 1,
        'Y' => 2,
        'Z' => 3,
        _ => throw new Exception("Invalid input"),
    };

    if (opponent == self)
        points += 3;
    else if (wins[opponent] == self)
        points += 6;
}


Console.WriteLine(points);