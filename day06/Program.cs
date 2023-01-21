// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllText(path);

var markerStart = 0;
for (int i = 0; i < data.Length - 4; i++)
{
    var marker = data.Substring(i, 4);
    if (marker.Distinct().Count() == 4)
    {
        markerStart = i + 4;
        break;
    }

}

Console.WriteLine($"Marker start: {markerStart}");
