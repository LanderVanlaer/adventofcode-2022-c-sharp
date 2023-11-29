// See https://aka.ms/new-console-template for more information


StreamReader file = new(args[0]);

int[] max = { 0, 0, 0 };
int totalOfElf = 0;

while (file.ReadLine() is { } line)
{
    if (string.IsNullOrEmpty(line))
    {
        int i;
        for (i = 0; i < max.Length; ++i)
            if (totalOfElf < max[i])
                break;

        --i;

        if (0 <= i)
        {
            int previousValue = max[i];
            max[i] = totalOfElf;

            for (int j = i - 1; 0 <= j; --j)
                (max[j], previousValue) = (previousValue, max[j]);
        }

        totalOfElf = 0;
    }
    else
    {
        totalOfElf += int.Parse(line);
    }
}

Console.WriteLine(string.Join('\n', max));
Console.WriteLine(max.Sum());