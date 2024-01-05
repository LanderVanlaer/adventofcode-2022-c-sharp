namespace _7;

public class File
{
    public File(string name, int size, Directory parent)
    {
        Name = name;
        Size = size;
        Parent = parent;
    }

    public string Name { get; set; }
    public int Size { get; set; }
    public Directory Parent { get; set; }
}