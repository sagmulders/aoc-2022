// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllLines(path);

var count = data.ToList().Where(x => overlaps(x)).Count();

Console.WriteLine($"With overlap {count}");

bool overlaps(string pair)
{
    // 6-6,4-6

    var one = pair.Split(",").First().Split("-").Select(x=> int.Parse(x));
    var two = pair.Split(",").Last().Split("-").Select(x=> int.Parse(x));

    // one in two
    return ((one.ElementAt(0) >= two.ElementAt(0) && one.ElementAt(1) <= two.ElementAt(1)) ||
     // two in one 
     two.ElementAt(0) >= one.ElementAt(0) && two.ElementAt(1) <= one.ElementAt(1));
}