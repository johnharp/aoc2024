using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace day06;

public class Data
{
    private static char upChar = '^';
    private static char downChar = 'v';
    private static char leftChar = '<';
    private static char rightChar = '>';
    private static char blockChar = '#';
    private static char visitedChar = 'X';

    private string guardSymbols = $"[{leftChar}{rightChar}{upChar}{downChar}]";
    private readonly List<char[]> _lines = new List<char[]>();
    private int _width = 0;
    private int _height = 0;
    private int _currX = 0;
    private int _currY = 0;
    private int _dirX = 0;
    private int _dirY = 0;

    private long _numVisitedSites = 0;

    public Data(string filename)
    {
        IEnumerable<string> lines = File.ReadLines(filename);

        int y = 0;
        foreach (string line in lines)
        {
            _lines.Add(line.ToCharArray());
            _height++;

            Match match = Regex.Match(line, guardSymbols);
            if (match.Success)
            {
                _currX = match.Index;
                _currY = y;

                if (match.Value == upChar.ToString())
                {
                    _dirX = 0;
                    _dirY = -1;
                }

                if (match.Value == downChar.ToString())
                {
                    _dirX = 0;
                    _dirY = 1;
                }

                if (match.Value == leftChar.ToString())
                {
                    _dirX = -1;
                    _dirY = 0;
                }

                if (match.Value == rightChar.ToString())
                {
                    _dirX = 1;
                    _dirY = 0;
                }
            }

            y++;
        }
        if (_lines.Count > 0)
        {
            _width = _lines[0].Length;
        }
    }

    public int Width()
    {
        return _width;
    }

    public int Height()
    {
        return _height;
    }

    public char Get(int x, int y)
    {
        if (x < 0 || x > _width - 1 || y < 0 || y > _height - 1)
        {
            return '\0';
        }
        else
        {
            return _lines[y][x];
        }
    }

    public char Get((int, int) xy)
    {
        return Get(xy.Item1, xy.Item2);
    }

    public void Set(int x, int y, char value)
    {
        if (x < 0 || x > _width - 1 || y < 0 || y > _height - 1)
        {
            return;
        }
        else
        {
            _lines[y][x] = value;
        }
    }

    public (int, int) Curr()
    {
        return (_currX, _currY);
    }

    public (int, int) Dir()
    {
        return (_dirX, _dirY);
    }

    public bool IsBlocked()
    {
        int newX = _currX + _dirX;
        int newY = _currY + _dirY;

        char symbolAtNew = Get(newX, newY);
        if (symbolAtNew == blockChar)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TurnRight()
    {
        if (_dirX == -1 && _dirY == 0)
        {
            _dirX = 0;
            _dirY = -1;
        }
        else if (_dirX == 0 && _dirY == -1)
        {
            _dirX = 1;
            _dirY = 0;
        }
        else if (_dirX == 1 && _dirY == 0)
        {
            _dirX = 0;
            _dirY = 1;
        }
        else if (_dirX == 0 && _dirY == 1)
        {
            _dirX = -1;
            _dirY = 0;
        }
    }

    public bool IsOnTheMap()
    {
        return _currX >= 0 && _currX < _width &&
            _currY >= 0 && _currY < _height;
    }

    public void Move()
    {
        if (!IsOnTheMap()) return;

        while (IsBlocked())
        {
            TurnRight();
        }

        int newX = _currX + _dirX;
        int newY = _currY + _dirY;

        char symbolAtNewPosition = Get(newX, newY);
        char symbolAtCurrPosition = Get(_currX, _currY);
        if (symbolAtNewPosition == blockChar) throw new Exception("This shouldn't happen!");

        if (symbolAtCurrPosition != visitedChar)
        {
            Set(_currX, _currY, visitedChar);
            _numVisitedSites++;
        }

        _currX = newX;
        _currY = newY;
    }

    public long NumVisitedSites()
    {
        return _numVisitedSites;
    }

    public void Telem()
    {
        Console.WriteLine($"at: {Curr()}\tfacing: {Dir()}\tblocked?: {IsBlocked()}\tvisited: {_numVisitedSites}");
    }
}