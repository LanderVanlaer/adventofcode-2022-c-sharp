StreamReader file = new(args[0]);

int counter = 0;
int sum = 0;
int signalStrength = 1;

while (file.ReadLine() is { } line)
    switch (line[0])
    {
        case 'n':
            ++counter;
            CalcSum();
            break;
        case 'a':
            ++counter;
            CalcSum();
            ++counter;
            CalcSum();

            signalStrength += int.Parse(line[5..]);
            break;
        default:
            throw new Exception();
    }

Console.WriteLine(sum);
return;

void CalcSum()
{
    if ((counter - 20) % 40 == 0)
        sum += signalStrength * counter;
}