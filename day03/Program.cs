// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var rucksacks = File.ReadAllLines(path);
var priority = 0;

for (int i = 0; i < rucksacks.Length / 3; i++)
{
    var group = rucksacks.Skip(i * 3).Take(3);
    
    var duplicate= GetDuplicate(group.ElementAt(0), group.ElementAt(1));
    duplicate = GetDuplicate(duplicate, group.ElementAt(2));


    priority += GetPrio(duplicate.Distinct().Single());
}

IEnumerable<char> GetDuplicate(IEnumerable<char> left, IEnumerable<char> right) {
    return left.Where(x => right.Contains(x)).Distinct();
}

int GetPrio(char c)
{
    if (char.IsLower(c))
        return (int)c - 96;
    else
        return (int)c - 64 + 26;
}

Console.WriteLine($"Priority {priority}");