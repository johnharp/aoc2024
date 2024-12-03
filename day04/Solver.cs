namespace day04;

using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;

public class Solver
{
    public long part1(string[] lines)
    {
        var input = parse(lines);
        return input.Sum(l => l.Count);
    }

    public long part2(string[] lines)
    {
        var input = parse(lines);
        return input.Sum(l => l.Count);
    }

    public List<List<string>> parse(string[] lines)
    {
        List<List<string>> result = new List<List<string>>();

        string pattern = @"\d+";
        Regex regex = new Regex(pattern);
        foreach(string line in lines)
        {
            List<string> lineResult = new List<string>();
            result.Add(lineResult);

            MatchCollection matches = regex.Matches(line);
            for (int i = 0; i < matches.Count; i++)
            {
                lineResult.Add(matches[i].Groups[0].Value);
            }

        }
        return result;
    }

}