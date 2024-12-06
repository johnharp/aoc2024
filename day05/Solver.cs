namespace day05;

using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Schema;
using System.Collections.Immutable;
using System.Data;

public class Solver
{
    Input input;

    public Solver(Input suppliedInput)
    {
        input = suppliedInput;
    }

    public long part1()
    {
        long solution = 0;

        foreach(var update in input.Updates)
        {
            if (input.RulesGraph.TestPath(update))
            {
                int midpoint = update.Count/2;
                int midvalue = update[midpoint];

                solution += midvalue;
            }
        }

        return solution;
    }

    public long part2()
    {
        long solution = 0;
        return solution;
    }

}