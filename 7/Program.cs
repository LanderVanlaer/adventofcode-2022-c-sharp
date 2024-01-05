using Directory = _7.Directory;

StreamReader file = new(args[0]);

Directory root = new("/");

Directory current = root;

while (file.ReadLine() is { } line)
{
    bool isCommand = line.StartsWith("$");
    if (isCommand)
    {
        switch (line[2..4])
        {
            case "ls":
                break;
            case "cd":
                current = line[5] == '/' ? root : current.NavigateAndCreate(line[5..]);
                break;
        }
    }
    else
    {
        // dir fwdwq
        // 2159 fzb.tjs

        if (line.StartsWith("dir")) // Directory
        {
            current.AddDirectory(line[4..]);
        }
        else // File
        {
            string[] parts = line.Split(' ');
            current.AddFile(parts[1], int.Parse(parts[0]));
        }
    }
}

Console.WriteLine(root.Size);

Console.WriteLine(GetSumOfSizesUnder(root, 100000));

return;

int GetSumOfSizesUnder(Directory directory, int under)
{
    int sum = 0;

    int size = directory.Size;
    if (size <= under)
        sum += size;

    sum += directory.Directories.Sum(subDirectory => GetSumOfSizesUnder(subDirectory, under));

    return sum;
}