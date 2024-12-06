namespace day06;

using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Schema;
using System.Collections.Immutable;
using System.Data;

public class Solver
{
    Data data;

    public Solver(Data suppliedData)
    {
        data = suppliedData;
    }

    public long part1()
    {
        while(data.IsOnTheMap())
        {
            data.Move();
        }
        return data.NumVisitedSites();
    }

    public long part2()
    {
        long solution = 0;

        return solution;
    }

}