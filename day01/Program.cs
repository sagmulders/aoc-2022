// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllLines(path);

List<Elf> elfs = new List<Elf>();

var elf = new Elf();

foreach (var line in data)
{
    if (line == "")
    {
        elfs.Add(elf);
        elf = new Elf();

    }
    else
    {
        elf.Food += int.Parse(line);
    }

}
elfs.Add(elf);

Console.WriteLine($"Elf with most calories: {elfs.OrderByDescending(x=>x.Food).First().Food}");
Console.WriteLine($"Elf top 3 total: {elfs.OrderByDescending(x=>x.Food).Take(3).Sum(x => x.Food)}");



class Elf
{
    public int Food { get; set; }
}