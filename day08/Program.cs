// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllLines(path);

int[,] trees = new int[data[0].Length, data.Length];

for (int i = 0; i < data.Length; i++)
{
    for (int j = 0; j < data[i].Length; j++)
    {
        trees[i, j] = int.Parse(data[i][j].ToString());
    }
}

int visible = 0;
for (int i = 1; i < data.Length - 2; i++)
{
    for (int j = 1; j < data[i].Length - 2; j++)
    {
        // row
        var rowVis = isVisible(i, data[i].Select(x => int.Parse(x.ToString())).ToArray());
        var colVis = isVisible(j, Enumerable.Range(0, 5).Select(x => trees[x,j]).ToArray());
        
        if(rowVis || colVis)
            visible++;

    }
}

bool isVisible(int pos, int[] row)
{
    Console.WriteLine($"Checking {row[pos]} in {row.ToString()}")
    // 25512
    var fromRight = row.Skip(pos + 1).All(x => x < row[pos]);

    // 21552
    var fromLeft = row.Reverse().Skip(row.Length - pos).All(x => x < row[pos]);

    return fromRight || fromLeft;
}




Console.WriteLine($"{visible}");
