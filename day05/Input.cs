namespace day05;

public class Input
{
    public List<List<string>> UpdatePageNumbersList = new List<List<string>>();
    public List<Dictionary<string, int>> UpdatePageNumbersIndexesList = new List<Dictionary<string,int>>();

    public Dictionary<string, HashSet<string>> PrecededByRules = new Dictionary<string, HashSet<string>>();

    public Input(string filename)
    {
        IEnumerable<string> lines = File.ReadLines(filename);

        bool sectionSeparatorFound = false;

        foreach (string line in lines)
        {
            if (line.Trim() == "")
            {
                sectionSeparatorFound = true;
                continue;
            }

            if (!sectionSeparatorFound) {
                // Handle first section of input
                var parts = line.Split("|");
                string first = parts[0];
                string after = parts[1];

                if (!PrecededByRules.Keys.Contains(after))
                {
                    PrecededByRules[after] = new HashSet<string>();
                }
                PrecededByRules[after].Add(first);
            }
            else
            {
                // Handle second section of input
                var parts = line.Split(",");
                var pageNumbersList = new List<string>(parts);
                UpdatePageNumbersList.Add(pageNumbersList);
                var index = indexPages(pageNumbersList);
                UpdatePageNumbersIndexesList.Add(index);
            }
        }
    }

    private static Dictionary<string, int> indexPages(List<string> pageNumbers)
    {
        Dictionary<string, int> index = new Dictionary<string, int>();
        for (int i = 0; i < pageNumbers.Count;  i++)
        {
            string pageNumber = pageNumbers[i];
            if (index.Keys.Contains(pageNumber))
            {
                throw new Exception("Unexpected condition -- page number appears twice in one line");
            }
            else
            {
                index[pageNumber] = i;
            }
        }
        return index;
    }
}