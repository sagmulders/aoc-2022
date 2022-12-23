// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var rucksacks = File.ReadAllLines(path);
var priority = 0;

foreach (var r in rucksacks)
{
    var left = r.Substring(0, r.Length / 2);
    var right = r.Substring(r.Length / 2);

    var duplicate = left.Where(x => right.Contains(x)).Distinct().Single();

    priority += GetPrio(duplicate);

}

int GetPrio(char c)
{
    if (char.IsLower(c))
        return (int)c - 96;
    else
        return (int)c - 64+26;
}

Console.WriteLine($"Priority {priority}");