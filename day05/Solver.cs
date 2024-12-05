namespace day05;

using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Schema;
using System.Collections.Immutable;

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

        for (int i = 0; i < input.UpdatePageNumbersList.Count; i++)
        {
            var update = input.UpdatePageNumbersList[i];

            if (isUpdateValid(update))
            {
                int middleIndex = update.Count / 2;
                string middlePage = update[middleIndex];
                solution += long.Parse(middlePage);
            }
        }
        return solution;
    }

    private bool isUpdateValid(List<string> update)
    {
        for (int j = 0; j < update.Count; j++)
        {
            string page = update[j];

            if (input.PrecededByRules.Keys.Contains(page))
            {
                HashSet<string> preceededBy = input.PrecededByRules[page];
                // we only need to check the reamining pages in the update
                // if the current page has any preceededBy rules
                for (int k = j + 1; k < update.Count; k++)
                {
                    string pageAfter = update[k];
                    if (preceededBy.Contains(pageAfter)) {
                        // invalid rule
                        return false;
                    }
                }

            }
        }
        return true;
    }

    public long part2()
    {
        long solution = 0;
        return solution;
    }

}