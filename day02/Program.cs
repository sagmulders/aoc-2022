// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var rounds = File.ReadAllLines(path).Select(x => new Round(x));

var score = rounds.Sum(x => x.GetScore());
Console.WriteLine($"Score: {score}");

class Round
{
    string o;
    string m;

    public Round(string s)
    {
        o = Convert(s.Substring(0, 1));
        m = Convert(s.Substring(2, 1));
    }

    private string Convert(string s)
    {
        if (s == "A" || s == "X")
            return "R";
        if (s == "B" || s == "Y")
            return "P";

        return "S";
    }



    public int GetScore()
    {
        var score = 0;

        if (o == "R" && m == "P" || o == "P" && m == "S" || o == "S" && m == "R")
            // win
            score += 6;
        else if (o == m)
            // draw
            score += 3;
        else
            // loss
            score += 0;

        if (m == "R")
            score += 1;

        if (m == "P")
            score += 2;

        if (m == "S")
            score += 3;

        return score;
    }
}