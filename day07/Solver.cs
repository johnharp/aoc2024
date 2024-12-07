using System.Numerics;
namespace day07;

public class Solver
{
    Data data;
    private static List<char> availableOps = new List<char> { '+', '*' };
    private static Dictionary<int, IEnumerable<IEnumerable<char>>> memoOpCombos = new Dictionary<int, IEnumerable<IEnumerable<char>>>();

    public Solver(Data suppliedData)
    {
        data = suppliedData;
    }

    public BigInteger part1()
    {
        BigInteger count = 0;
        BigInteger sum = 0;

        for (int i = 0; i < data.Results.Count; i++)
        {
            BigInteger targetResult = data.Results[i];
            List<BigInteger> operands = data.Operands[i];

            var opCombos = GetPermutations(availableOps, operands.Count - 1).ToList();

            for (int j = 0; j < opCombos.Count; j++) {
                var ops = opCombos[j].ToList();
                var result = compute(operands, ops);

                if (result == targetResult) {
                    count++;
                    sum += result;
                    break;
                }
            }
        }
        return sum;
    }

    public BigInteger part2()
    {
        return 0;
    }

    public IEnumerable<IEnumerable<char>> GetPermutations(IEnumerable<char> input, int length)
    {
        if (memoOpCombos.Keys.Contains(length)) {
            return memoOpCombos[length];
        }

        IEnumerable<IEnumerable<char>> ret;

        if (length < 1) ret = new List<List<char>>();
        else if (length == 1) ret = input.Select(x => new List<char> { x });
        else ret = GetPermutations(input, length - 1)
            .SelectMany(x => input,
                (x1, x2) => x1.Concat(new List<char> { x2 }));

        memoOpCombos[length] = ret;
        return ret;
    }

    public BigInteger compute(List<BigInteger> operands, List<char> operations)
    {
        if (operations.Count != operands.Count - 1 || operands.Count < 2)
        {
            throw new ArgumentException("Must have at least 2 operands and one fewer operation than operands");
        }

        BigInteger acc = operands[0];
        for (int i = 1; i < operands.Count; i++)
        {
            if (operations[i - 1] == '*')
            {
                acc *= operands[i];
            }
            else if (operations[i - 1] == '+')
            {
                acc += operands[i];
            }
            else
            {
                throw new ArgumentException($"Unknown operation {operations[i - 1]}");
            }
        }
        return acc;
    }

}