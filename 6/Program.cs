StreamReader file = new(args[0]);

char[] buffer = new char[14];
int location;

for (location = 0; location < 3; location++)
    buffer[location] = (char)file.Read();

for (char c; (c = (char)file.Read()) != '\uffff'; ++location)
{
    buffer[location % buffer.Length] = c;

    if (!HasDuplicates(buffer)) break;
}

Console.WriteLine(string.Join("", buffer) + " after " + (location + 1) + " chars");


return;

bool HasDuplicates(IReadOnlyList<char> arr)
{
    for (int i = 0; i < arr.Count; i++)
    for (int j = i + 1; j < arr.Count; j++)
        if (arr[i] == arr[j])
            return true;

    return false;
}