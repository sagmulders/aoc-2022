internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var path = Path.Combine(Environment.CurrentDirectory, "data");
        var data = File.ReadAllLines(path);

        var root = new Item() { Name = "/" };
        var current = root;

        foreach (var line in data)
        {
            var parts = line.Split(" ");

            if (line.StartsWith("$"))
            {
                // command
                switch (parts[1])
                {
                    case "cd":
                        {
                            switch (parts[2])
                            {
                                case "..":
                                    {
                                        // go up
                                        current = current.Parent;

                                        break;
                                    }
                                case "/":
                                    {
                                        current = root;
                                        break;
                                    }
                                default:
                                    {
                                        // go to dir
                                        current = current.Items.Single(x => x.Name == parts[2]);

                                        break;
                                    }
                            }

                            break;
                        }
                }

            }
            else if (line.StartsWith("dir"))
            {
                var newDir = new Item(current, parts[1], isDir: true);
                current.Items.Add(newDir);
            }
            else
            {
                // file in current dir
                var newFile = new Item(current, parts[1], size: int.Parse(parts[0]));
                current.Items.Add(newFile);
            }

        }

        var f = root.Flatten().Where(x => x.IsDir && x.GetTotalSize() < 100000);

        Console.WriteLine($"Total size {root.GetTotalSize()} {f.Sum(x => x.GetTotalSize())}");
    }
}

class Item
{
    public Item()
    {
        Items = new List<Item>();
    }

    public Item(Item parent, string name, int size = 0, bool isDir = false) : this()
    {
        Parent = parent;
        Name = name;
        Size = size;
        IsDir = isDir;
    }

    public bool IsDir { get; private set; }

    public List<Item> Items { get; set; }

    public Item Parent { get; set; }

    public int Size { get; set; }

    public string Name { get; set; }

    public int GetTotalSize()
    {
        var files = Items.Sum(x => x.Size);
        var dirs = Items.Sum(x => x.GetTotalSize());

        return files + dirs;
    }

    public IEnumerable<Item> Flatten()
    {
        yield return this;

        foreach (var node in Items.SelectMany(child => child.Flatten()))
        {
            yield return node;
        }
    }
}