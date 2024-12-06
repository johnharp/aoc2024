using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace day05;

public class Digraph
{
    private readonly int _V;
    private int _E;
    private readonly HashSet<int>[] _adj;

    public Digraph(int V)
    {
        _V = V;
        _E = 0;

        _adj = new HashSet<int>[V];
        for (int v = 0; v < V; v++)
        {
            _adj[v] = [];
        }
    }

    public int V()
    {
        return _V;
    }

    public int E()
    {
        return _E;
    }

    public void AddEdge(int v, int w)
    {
        _adj[v].Add(w);
        _E++;
    }

    public HashSet<int> Adj(int v)
    {
        return _adj[v];
    }

    public Digraph Reverse()
    {
        Digraph R = new Digraph(_V);
        for (int v = 0; v < _V; v++)
        {
            foreach(int w in _adj[v])
            {
                R.AddEdge(w, v);
            }
        }
        return R;
    }

    public bool TestPath(List<int> path)
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            int v = path[i];
            int w = path[i + 1];
            
            if (!_adj[v].Contains(w)) return false;
        }
        return true;
    }
}