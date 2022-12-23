// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllLines(path);

var count = data.ToList().Where(x => overlaps(x)).Count();

Console.WriteLine($"With overlap {count}");

bool overlaps(string pair)
{
    // 6-6,4-6

    var one = pair.Split(",").First().Split("-").Select(x => int.Parse(x)).ToArray();
    var two = pair.Split(",").Last().Split("-").Select(x => int.Parse(x)).ToArray();

    // one in two
    return ((one[0] >= two[0] && one[0] <= two[1]) ||
     // two in one 
     one[1] >= two[0] && one[0] <= two[1]);
}