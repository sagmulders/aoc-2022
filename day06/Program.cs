// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllText(path);

var markerStart = 0;
var messages=0;

for (int i = 0; i < data.Length - 14; i++)
{
    // find marker
    var marker = data.Substring(i, 14);
    if (marker.Distinct().Count() == 14)
    {
        markerStart = i + 14;
        break;
    }

}

Console.WriteLine($"Marker start: {markerStart}");
