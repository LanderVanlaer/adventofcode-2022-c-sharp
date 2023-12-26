StreamReader file = new(args[0]);

int sum = 0;

while (file.ReadLine() is { } line)
{
    int i = line.IndexOf(',');
    Elf elfOne = Elf.Parse(line[..i]);
    Elf elfTwo = Elf.Parse(line[(i + 1)..]);

    if (elfOne.IncludesElve(elfTwo) || elfTwo.IncludesElve(elfOne))
        ++sum;
}


Console.WriteLine(sum);

internal readonly struct Elf
{
    public readonly int StartId;
    public readonly int EndId;

    public Elf(int startId, int endId)
    {
        StartId = startId;
        EndId = endId;
    }

    public static Elf Parse(string line)
    {
        int i = line.IndexOf('-');
        string start = line[..i];
        string end = line[(i + 1)..];
        return new Elf(int.Parse(start), int.Parse(end));
    }

    public bool IncludesElve(Elf elf) => StartId <= elf.StartId && elf.EndId <= EndId;
}