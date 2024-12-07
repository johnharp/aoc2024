namespace day07;

using System.Text.RegularExpressions;

public class Data
{
    private static string pattern = @"(\d+):\s+(\d+(?:\s+\d+)+)";

    public List<long> Results = new List<long>();
    public List<List<long>> Operands = new List<List<long>>();

    public Data(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            Match match = Regex.Match(line, pattern);
            if (match.Success)
            {
                string value1 = match.Groups[1].Value;
                string value2 = match.Groups[2].Value;
                long result = long.Parse(value1);

                Results.Add(result);

                string[] operandStrings = value2.Split(' ');
                List<long> operands = operandStrings.Select(x => long.Parse(x)).ToList();
                Operands.Add(operands);
            }
            else
            {
                throw new Exception($"Malformed input line: {line}");
            }
        }
    }
}