StreamReader file = new(args[0]);

Dictionary<char, char> wins = new()
{
    { 'A', 'B' },
    { 'B', 'C' },
    { 'C', 'A' },
};
Dictionary<char, char> loses = new()
{
    { 'A', 'C' },
    { 'B', 'A' },
    { 'C', 'B' },
};

int points = 0;

while (file.ReadLine() is { } line)
{
    char opponent = line[0];
    char self = line[2] switch
    {
        // Lose
        'X' => loses[opponent],
        // Draw
        'Y' => opponent,
        // Win
        'Z' => wins[opponent],
        _ => throw new Exception("Invalid input"),
    };

    points += self switch
    {
        'A' => 1,
        'B' => 2,
        'C' => 3,
        _ => throw new Exception("Invalid input"),
    };

    if (opponent == self)
        points += 3;
    else if (wins[opponent] == self)
        points += 6;
}


Console.WriteLine(points);