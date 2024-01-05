namespace _7;

public class Directory
{
    public readonly List<Directory> Directories = new();

    public readonly List<File> Files = new();
    public readonly string Name;
    public readonly Directory? Parent;

    public Directory(string name, Directory? parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public int Size => Files.Sum(file => file.Size) + Directories.Sum(directory => directory.Size);

    public File AddFile(string name, int size)
    {
        File file = new(name, size, this);
        Files.Add(file);
        return file;
    }

    public Directory AddDirectory(string name)
    {
        Directory directory = new(name, this);
        Directories.Add(directory);
        return directory;
    }

    public Directory? GetDirectory(string name) => Directories.Find(directory => directory.Name == name);

    public Directory NavigateAndCreate(string name)
    {
        if (name == "..") return Parent ?? this;

        if (GetDirectory(name) is { } directory) return directory;

        return AddDirectory(name);
    }
}