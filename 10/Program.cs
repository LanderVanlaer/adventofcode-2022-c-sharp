using _10;

StreamReader file = new(args[0]);

Crt crt = new();
Sprite sprite = new();

while (file.ReadLine() is { } line)
    switch (line[0])
    {
        case 'n':
            crt.Set(sprite.IsSet(crt.Index));
            break;
        case 'a':
            crt.Set(sprite.IsSet(crt.Index));
            crt.Set(sprite.IsSet(crt.Index));
            sprite.Add(int.Parse(line[5..]));
            break;
        default:
            throw new Exception();
    }

Console.WriteLine(crt.ToDisplayString());