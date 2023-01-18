using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var path = Path.Combine(Environment.CurrentDirectory, "data");
        var data = File.ReadAllLines(path);

        var stacks = GetStacks(data.Where(x => !x.StartsWith("move")).Reverse().Skip(2));

        foreach (var step in data.Where(x => x.StartsWith("move")))
        {
            var parts = step.Split(" ");

            for (int i = 0; i < int.Parse(parts[1]); i++)
            {
                var item = stacks[int.Parse(parts[3]) - 1].Pop();

                stacks[int.Parse(parts[5]) - 1].Push(item);

            }

        }

        Console.WriteLine($"{string.Join("",stacks.Select(x => x.Peek()))}");

    }

    static Stack<string>[] GetStacks(IEnumerable<string> data)
    {
        var nr = (data.First().Count() + 1) / 4;
        Stack<string>[] stacks = new Stack<string>[nr];
        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<string>();
        }


        foreach (var line in data)
        {
            for (var i = 0; i < nr; i++)
            {
                var part = line.Substring(i * 4, 3);
                if (!string.IsNullOrWhiteSpace(part))
                    stacks[i].Push(part.Trim().ElementAt(1).ToString());
            }

        }

        return stacks;
    }
}